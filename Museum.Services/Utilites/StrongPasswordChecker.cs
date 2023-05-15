namespace Museum.App.Services.Utilites
{
    public class StrongPasswordChecker
    {
        private readonly string password;
        private int missingType;
        private int oneRepeats;
        private int twoRepeats;

        public StrongPasswordChecker(string password)
        {
            this.password = password;
            missingType = 0;
            oneRepeats = 0;
            twoRepeats = 0;
        }

        public async Task<bool> IsPasswordStrongAsync()
        {
            return 0 == await GetStrongPasswordChangesAsync();
        }

        public async Task<int> GetStrongPasswordChangesAsync()
        {
            await GetMissingTypesAsync();
            int length = password.Length;

            if (length < 6)
            {
                return Math.Max(missingType, 6 - length);
            }
            else if (length <= 20)
            {
                return Math.Max(missingType, GetChangesNeeded());
            }
            else
            {
                int changesNeeded = GetChangesNeeded();
                int deletionsNeeded = GetDeletionsNeeded();

                changesNeeded -= Math.Min(deletionsNeeded, oneRepeats);
               
                changesNeeded -= Math.Min(Math.Max(deletionsNeeded - oneRepeats, 0), twoRepeats * 2) / 2;
                
                changesNeeded -= Math.Max(deletionsNeeded - oneRepeats - 2 * twoRepeats, 0) / 3;
                
                return deletionsNeeded + Math.Max(missingType, changesNeeded);
            }
        }

        private async Task GetMissingTypesAsync()
        {
            missingType = 3;
            if (await Task.Run(() => password.Any(char.IsLower)))
                missingType--;
            if (await Task.Run(() => password.Any(char.IsUpper))) 
                missingType--;
            if (await Task.Run(() => password.Any(char.IsDigit))) 
                missingType--;
        }

        private int GetChangesNeeded()
        {
            int changesNeeded = 0;
            char prev = '\0', 
                 curr;

            for (int i = 0; i < password.Length; i++)
            {
                curr = password[i];
                if (i >= 2 && prev == curr && prev == password[i - 1])
                {
                    int length = 2;
                    for (; i < password.Length && password[i] == password[i - 1]; i++)
                    {
                        length++;
                    }

                    if (length % 3 == 0)
                    {
                        oneRepeats++;
                    }
                    else if (length % 3 == 1)
                    {
                        twoRepeats++;
                    }

                    changesNeeded += length / 3;
                }
                prev = curr;
            }

            return changesNeeded;
        }

        private int GetDeletionsNeeded()
        {
            int deletionsNeeded = Math.Max(password.Length - 20, 0);

            deletionsNeeded += Math.Max(GetChangesNeeded() - Math.Min(oneRepeats, Math.Max(0, password.Length - 20 - oneRepeats)) * 2, 0) / 3;
            
            return deletionsNeeded;
        }
    }
}

