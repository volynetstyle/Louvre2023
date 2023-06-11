use LouvreDatabase

CREATE TABLE [dbo].[ApplicationRole]
(
	[ApplicationRole_ID] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(256) NOT NULL,
    [NormalizedName] NVARCHAR(256) NOT NULL
)

GO
CREATE INDEX [IX_ApplicationRole_NormalizedName] ON [dbo].[ApplicationRole] ([NormalizedName])

CREATE TABLE [dbo].[ApplicationUser]
(
	[ApplicationUser_ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[UserAvatar] NVARCHAR (256) NULL,
    [UserName] NVARCHAR(256) NOT NULL,
    [NormalizedUserName] NVARCHAR(256) NOT NULL,
    [Email] NVARCHAR(256) NULL,
    [NormalizedEmail] NVARCHAR(256) NULL,
    [EmailConfirmed] BIT NOT NULL,
    [PasswordHash] NVARCHAR(MAX) NULL,
    [PhoneNumber] NVARCHAR(50) NULL,
    [PhoneNumberConfirmed] BIT NOT NULL,
    [TwoFactorEnabled] BIT NOT NULL
)

GO

CREATE INDEX [IX_ApplicationUser_NormalizedUserName] ON [dbo].[ApplicationUser] ([NormalizedUserName])

GO

CREATE INDEX [IX_ApplicationUser_NormalizedEmail] ON [dbo].[ApplicationUser] ([NormalizedEmail])

CREATE TABLE [dbo].[ApplicationUserRole]
(
	[User_ID] INT NOT NULL,
	[Role_ID] INT NOT NULL
    PRIMARY KEY ([User_ID], [Role_ID]),
    CONSTRAINT[FK_ApplicationUserRole_User] FOREIGN KEY ([User_ID]) REFERENCES [ApplicationUser]([ApplicationUser_ID]),
    CONSTRAINT[FK_ApplicationUserRole_Role] FOREIGN KEY ([Role_ID]) REFERENCES [ApplicationRole]([ApplicationRole_ID])
)

select * from ApplicationRole
select * from ApplicationUser
select * from ApplicationUserRole


CREATE TABLE Comments (
    Comment_ID INT NOT NULL PRIMARY KEY IDENTITY,
    CommentText VARCHAR(255),
	[User_ID] INT NOT NULL,
	CONSTRAINT[FK_ApplicationUserRole_User_Comment] FOREIGN KEY ([User_ID]) REFERENCES [ApplicationUser]([ApplicationUser_ID]),
);

CREATE TABLE CommentReplies (
    ParentComment_ID INT,
    ReplyComment_ID INT,
    PRIMARY KEY ([ParentComment_ID], [ReplyComment_ID]),
    FOREIGN KEY (ParentComment_ID) REFERENCES Comments(Comment_ID),
    FOREIGN KEY (ReplyComment_ID) REFERENCES Comments(Comment_ID)
);


drop table CommentReplies
drop table  Comments

ALTER TABLE Raiting
ADD ApplicationUser_ID INT NOT NULL
ALTER TABLE Raiting
ADD CONSTRAINT FK_Raiting_User FOREIGN KEY (ApplicationUser_ID) REFERENCES ApplicationUser(ApplicationUser_ID);

CREATE TABLE Comments (
    Comment_ID INT NOT NULL PRIMARY KEY IDENTITY,
    CommentText VARCHAR(255),
    [User_ID] INT NOT NULL,
    ParentComment_ID INT,
    CONSTRAINT [FK_ApplicationUserRole_User_Comment] FOREIGN KEY ([User_ID]) REFERENCES [ApplicationUser]([ApplicationUser_ID]),
    CONSTRAINT [FK_Comments_ParentComment] FOREIGN KEY (ParentComment_ID) REFERENCES Comments(Comment_ID)
);
