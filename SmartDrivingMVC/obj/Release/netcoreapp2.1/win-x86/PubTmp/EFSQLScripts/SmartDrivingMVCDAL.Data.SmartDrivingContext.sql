IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE TABLE [PostalDistrict] (
        [PostalDistrictId] int NOT NULL IDENTITY,
        [City] nvarchar(max) NOT NULL,
        [Zipcode] int NOT NULL,
        CONSTRAINT [PK_PostalDistrict] PRIMARY KEY ([PostalDistrictId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE TABLE [Vehicle] (
        [VehicleId] int NOT NULL IDENTITY,
        [VehicleModel] nvarchar(max) NULL,
        [RegistrationDtl] nvarchar(max) NULL,
        CONSTRAINT [PK_Vehicle] PRIMARY KEY ([VehicleId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE TABLE [Customer] (
        [CustomerId] int NOT NULL IDENTITY,
        [FirstName] nvarchar(50) NOT NULL,
        [LastName] nvarchar(50) NOT NULL,
        [EmailAddress] nvarchar(100) NULL,
        [Street] nvarchar(100) NULL,
        [DateBirth] datetime2 NOT NULL,
        [MobilePhone] nvarchar(100) NULL,
        [PostalDistrictId] int NULL,
        [AspNetUserId] nvarchar(max) NULL,
        CONSTRAINT [PK_Customer] PRIMARY KEY ([CustomerId]),
        CONSTRAINT [FK_Customer_PostalDistrict_PostalDistrictId] FOREIGN KEY ([PostalDistrictId]) REFERENCES [PostalDistrict] ([PostalDistrictId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE TABLE [Staff] (
        [StaffId] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [EmailAddress] nvarchar(max) NULL,
        [Street] nvarchar(max) NULL,
        [MobilePhone] nvarchar(max) NULL,
        [PostalDistrictId] int NULL,
        CONSTRAINT [PK_Staff] PRIMARY KEY ([StaffId]),
        CONSTRAINT [FK_Staff_PostalDistrict_PostalDistrictId] FOREIGN KEY ([PostalDistrictId]) REFERENCES [PostalDistrict] ([PostalDistrictId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE TABLE [BookingLog] (
        [BookingLogId] int NOT NULL IDENTITY,
        [CreatedBy] nvarchar(max) NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(max) NULL,
        [StaffId] int NULL,
        [CustomerId] int NULL,
        CONSTRAINT [PK_BookingLog] PRIMARY KEY ([BookingLogId]),
        CONSTRAINT [FK_BookingLog_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([CustomerId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_BookingLog_Staff_StaffId] FOREIGN KEY ([StaffId]) REFERENCES [Staff] ([StaffId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE TABLE [ActivityType] (
        [ActivityTypeId] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Price] int NOT NULL,
        [StartDate] datetime2 NOT NULL,
        [EndDate] datetime2 NOT NULL,
        [BookingLogId] int NOT NULL,
        [VehicleId] int NOT NULL,
        CONSTRAINT [PK_ActivityType] PRIMARY KEY ([ActivityTypeId]),
        CONSTRAINT [FK_ActivityType_BookingLog_BookingLogId] FOREIGN KEY ([BookingLogId]) REFERENCES [BookingLog] ([BookingLogId]) ON DELETE CASCADE,
        CONSTRAINT [FK_ActivityType_Vehicle_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicle] ([VehicleId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE TABLE [Evaluation] (
        [EvaluationId] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Resulte] nvarchar(max) NULL,
        [ActivityTypeId] int NOT NULL,
        CONSTRAINT [PK_Evaluation] PRIMARY KEY ([EvaluationId]),
        CONSTRAINT [FK_Evaluation_ActivityType_ActivityTypeId] FOREIGN KEY ([ActivityTypeId]) REFERENCES [ActivityType] ([ActivityTypeId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'StaffId', N'EmailAddress', N'FirstName', N'LastName', N'MobilePhone', N'PostalDistrictId', N'Street') AND [object_id] = OBJECT_ID(N'[Staff]'))
        SET IDENTITY_INSERT [Staff] ON;
    INSERT INTO [Staff] ([StaffId], [EmailAddress], [FirstName], [LastName], [MobilePhone], [PostalDistrictId], [Street])
    VALUES (1, N'has@ertr.dk', N'Hashi', N'Booba', N'52634175', NULL, N'Langkærevej 78');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'StaffId', N'EmailAddress', N'FirstName', N'LastName', N'MobilePhone', N'PostalDistrictId', N'Street') AND [object_id] = OBJECT_ID(N'[Staff]'))
        SET IDENTITY_INSERT [Staff] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'StaffId', N'EmailAddress', N'FirstName', N'LastName', N'MobilePhone', N'PostalDistrictId', N'Street') AND [object_id] = OBJECT_ID(N'[Staff]'))
        SET IDENTITY_INSERT [Staff] ON;
    INSERT INTO [Staff] ([StaffId], [EmailAddress], [FirstName], [LastName], [MobilePhone], [PostalDistrictId], [Street])
    VALUES (2, N'YTR@ertr.dk', N'Jens', N'Rasmussen', N'63524174', NULL, N'Sønderhøj Alle 4');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'StaffId', N'EmailAddress', N'FirstName', N'LastName', N'MobilePhone', N'PostalDistrictId', N'Street') AND [object_id] = OBJECT_ID(N'[Staff]'))
        SET IDENTITY_INSERT [Staff] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'StaffId', N'EmailAddress', N'FirstName', N'LastName', N'MobilePhone', N'PostalDistrictId', N'Street') AND [object_id] = OBJECT_ID(N'[Staff]'))
        SET IDENTITY_INSERT [Staff] ON;
    INSERT INTO [Staff] ([StaffId], [EmailAddress], [FirstName], [LastName], [MobilePhone], [PostalDistrictId], [Street])
    VALUES (3, N'ljs@ljk.dk', N'Louis', N'Jacobson', N'25454175', NULL, N'Louisvej 45');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'StaffId', N'EmailAddress', N'FirstName', N'LastName', N'MobilePhone', N'PostalDistrictId', N'Street') AND [object_id] = OBJECT_ID(N'[Staff]'))
        SET IDENTITY_INSERT [Staff] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE INDEX [IX_ActivityType_BookingLogId] ON [ActivityType] ([BookingLogId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE INDEX [IX_ActivityType_VehicleId] ON [ActivityType] ([VehicleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE INDEX [IX_BookingLog_CustomerId] ON [BookingLog] ([CustomerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE INDEX [IX_BookingLog_StaffId] ON [BookingLog] ([StaffId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE INDEX [IX_Customer_PostalDistrictId] ON [Customer] ([PostalDistrictId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE INDEX [IX_Evaluation_ActivityTypeId] ON [Evaluation] ([ActivityTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    CREATE INDEX [IX_Staff_PostalDistrictId] ON [Staff] ([PostalDistrictId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212071430_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191212071430_init', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212094743_ActivityTypeBooking')
BEGIN
    ALTER TABLE [ActivityType] DROP CONSTRAINT [FK_ActivityType_BookingLog_BookingLogId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212094743_ActivityTypeBooking')
BEGIN
    ALTER TABLE [ActivityType] DROP CONSTRAINT [FK_ActivityType_Vehicle_VehicleId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212094743_ActivityTypeBooking')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ActivityType]') AND [c].[name] = N'VehicleId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ActivityType] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [ActivityType] ALTER COLUMN [VehicleId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212094743_ActivityTypeBooking')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ActivityType]') AND [c].[name] = N'BookingLogId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ActivityType] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [ActivityType] ALTER COLUMN [BookingLogId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212094743_ActivityTypeBooking')
BEGIN
    ALTER TABLE [ActivityType] ADD CONSTRAINT [FK_ActivityType_BookingLog_BookingLogId] FOREIGN KEY ([BookingLogId]) REFERENCES [BookingLog] ([BookingLogId]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212094743_ActivityTypeBooking')
BEGIN
    ALTER TABLE [ActivityType] ADD CONSTRAINT [FK_ActivityType_Vehicle_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicle] ([VehicleId]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212094743_ActivityTypeBooking')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191212094743_ActivityTypeBooking', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212130345_changedBookinkActivity')
BEGIN
    ALTER TABLE [ActivityType] DROP CONSTRAINT [FK_ActivityType_BookingLog_BookingLogId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212130345_changedBookinkActivity')
BEGIN
    DROP INDEX [IX_ActivityType_BookingLogId] ON [ActivityType];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212130345_changedBookinkActivity')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ActivityType]') AND [c].[name] = N'BookingLogId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [ActivityType] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [ActivityType] DROP COLUMN [BookingLogId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212130345_changedBookinkActivity')
BEGIN
    ALTER TABLE [BookingLog] ADD [ActivityTypeId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212130345_changedBookinkActivity')
BEGIN
    CREATE INDEX [IX_BookingLog_ActivityTypeId] ON [BookingLog] ([ActivityTypeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212130345_changedBookinkActivity')
BEGIN
    ALTER TABLE [BookingLog] ADD CONSTRAINT [FK_BookingLog_ActivityType_ActivityTypeId] FOREIGN KEY ([ActivityTypeId]) REFERENCES [ActivityType] ([ActivityTypeId]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191212130345_changedBookinkActivity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191212130345_changedBookinkActivity', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191213072100_datatime')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191213072100_datatime', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191213073500_data')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191213073500_data', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191213073659_dataFormat')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191213073659_dataFormat', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191213074631_CleaningModels')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191213074631_CleaningModels', N'2.1.11-servicing-32099');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191213085040_EvaluationToBookingLog')
BEGIN
    ALTER TABLE [Evaluation] DROP CONSTRAINT [FK_Evaluation_ActivityType_ActivityTypeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191213085040_EvaluationToBookingLog')
BEGIN
    DROP INDEX [IX_Evaluation_ActivityTypeId] ON [Evaluation];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191213085040_EvaluationToBookingLog')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Evaluation]') AND [c].[name] = N'ActivityTypeId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Evaluation] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Evaluation] DROP COLUMN [ActivityTypeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191213085040_EvaluationToBookingLog')
BEGIN
    ALTER TABLE [Evaluation] ADD [BookingLogId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191213085040_EvaluationToBookingLog')
BEGIN
    CREATE INDEX [IX_Evaluation_BookingLogId] ON [Evaluation] ([BookingLogId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191213085040_EvaluationToBookingLog')
BEGIN
    ALTER TABLE [Evaluation] ADD CONSTRAINT [FK_Evaluation_BookingLog_BookingLogId] FOREIGN KEY ([BookingLogId]) REFERENCES [BookingLog] ([BookingLogId]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191213085040_EvaluationToBookingLog')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191213085040_EvaluationToBookingLog', N'2.1.11-servicing-32099');
END;

GO

