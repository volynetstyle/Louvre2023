
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
	[UserId] INT NOT NULL,
	[RoleId] INT NOT NULL
    PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_ApplicationUserRole_User] FOREIGN KEY ([UserId]) REFERENCES [ApplicationUser]([Id]),
    CONSTRAINT [FK_ApplicationUserRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [ApplicationRole]([Id])
)

select * from ApplicationRole
select * from ApplicationUser
select * from ApplicationUserRole


CREATE TABLE Comments (
    [CommentReplies_ID] INT NOT NULL PRIMARY KEY IDENTITY,
    CommentId INT PRIMARY KEY,
    CommentText VARCHAR(255)
);

CREATE TABLE CommentReplies (
    ParentCommentId INT,
    ReplyCommentId INT,
    PRIMARY KEY ([ParentCommentIdd], [ReplyCommentId]),
    FOREIGN KEY (ParentCommentId) REFERENCES Comments(CommentId),
    FOREIGN KEY (ReplyCommentId) REFERENCES Comments(CommentId)
);
