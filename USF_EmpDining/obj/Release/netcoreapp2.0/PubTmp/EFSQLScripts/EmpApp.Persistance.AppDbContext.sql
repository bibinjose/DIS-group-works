IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20171225074848_initialMigraations')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20171225074848_initialMigraations', N'2.0.2-rtm-10011');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20171225075959_SeedData')
BEGIN
    CREATE TABLE [Employees] (
        [Id] int NOT NULL IDENTITY,
        [Age] int NOT NULL,
        [Name] nvarchar(255) NOT NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20171225075959_SeedData')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20171225075959_SeedData', N'2.0.2-rtm-10011');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180420232825_leave')
BEGIN
    EXEC sp_rename N'Employees.Id', N'EmpId', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180420232825_leave')
BEGIN
    ALTER TABLE [Employees] ADD [Designation] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180420232825_leave')
BEGIN
    CREATE TABLE [Leaves] (
        [LeaveId] int NOT NULL IDENTITY,
        [ApprovalStatus] nvarchar(max) NULL,
        [EmployeeEmpId] int NULL,
        [EndDate] datetime2 NOT NULL,
        [StartDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Leaves] PRIMARY KEY ([LeaveId]),
        CONSTRAINT [FK_Leaves_Employees_EmployeeEmpId] FOREIGN KEY ([EmployeeEmpId]) REFERENCES [Employees] ([EmpId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180420232825_leave')
BEGIN
    CREATE INDEX [IX_Leaves_EmployeeEmpId] ON [Leaves] ([EmployeeEmpId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180420232825_leave')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180420232825_leave', N'2.0.2-rtm-10011');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180420233603_leave1')
BEGIN
    ALTER TABLE [Leaves] DROP CONSTRAINT [FK_Leaves_Employees_EmployeeEmpId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180420233603_leave1')
BEGIN
    EXEC sp_rename N'Leaves.EmployeeEmpId', N'EmployeeId', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180420233603_leave1')
BEGIN
    EXEC sp_rename N'Leaves.IX_Leaves_EmployeeEmpId', N'IX_Leaves_EmployeeId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180420233603_leave1')
BEGIN
    EXEC sp_rename N'Employees.EmpId', N'Id', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180420233603_leave1')
BEGIN
    ALTER TABLE [Leaves] ADD CONSTRAINT [FK_Leaves_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180420233603_leave1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180420233603_leave1', N'2.0.2-rtm-10011');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180421071008_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180421071008_initial', N'2.0.2-rtm-10011');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180421212417_leavesCrud')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180421212417_leavesCrud', N'2.0.2-rtm-10011');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180422192311_InitialCreat1')
BEGIN
    CREATE TABLE [Schedules] (
        [ScheduleId] int NOT NULL IDENTITY,
        [EmployeeId] int NULL,
        [EndTime] datetime2 NOT NULL,
        [ScheduleDate] datetime2 NOT NULL,
        [StartTime] datetime2 NOT NULL,
        [WorkLocation] nvarchar(max) NULL,
        CONSTRAINT [PK_Schedules] PRIMARY KEY ([ScheduleId]),
        CONSTRAINT [FK_Schedules_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180422192311_InitialCreat1')
BEGIN
    CREATE INDEX [IX_Schedules_EmployeeId] ON [Schedules] ([EmployeeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180422192311_InitialCreat1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180422192311_InitialCreat1', N'2.0.2-rtm-10011');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180422195134_InitialCreat2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180422195134_InitialCreat2', N'2.0.2-rtm-10011');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180422211044_payment')
BEGIN
    CREATE TABLE [Payments] (
        [PaymentId] int NOT NULL IDENTITY,
        [EmployeeId] int NULL,
        [HourlyWage] real NOT NULL,
        [HoursWorked] real NOT NULL,
        [PaymentDate] datetime2 NOT NULL,
        [PaymentType] nvarchar(max) NULL,
        [Salary] real NOT NULL,
        CONSTRAINT [PK_Payments] PRIMARY KEY ([PaymentId]),
        CONSTRAINT [FK_Payments_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180422211044_payment')
BEGIN
    CREATE INDEX [IX_Payments_EmployeeId] ON [Payments] ([EmployeeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180422211044_payment')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180422211044_payment', N'2.0.2-rtm-10011');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180422225906_InitialCreat28')
BEGIN
    CREATE TABLE [Awards] (
        [AwardId] int NOT NULL IDENTITY,
        [AwardName] nvarchar(max) NOT NULL,
        [EmployeeId] int NULL,
        [PrizeAmount] int NOT NULL,
        CONSTRAINT [PK_Awards] PRIMARY KEY ([AwardId]),
        CONSTRAINT [FK_Awards_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180422225906_InitialCreat28')
BEGIN
    CREATE INDEX [IX_Awards_EmployeeId] ON [Awards] ([EmployeeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180422225906_InitialCreat28')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180422225906_InitialCreat28', N'2.0.2-rtm-10011');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180422234146_accessory')
BEGIN
    CREATE TABLE [Accessories] (
        [AccessoryId] int NOT NULL IDENTITY,
        [AccessoryName] nvarchar(max) NOT NULL,
        [EmployeeId] int NULL,
        CONSTRAINT [PK_Accessories] PRIMARY KEY ([AccessoryId]),
        CONSTRAINT [FK_Accessories_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180422234146_accessory')
BEGIN
    CREATE INDEX [IX_Accessories_EmployeeId] ON [Accessories] ([EmployeeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180422234146_accessory')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180422234146_accessory', N'2.0.2-rtm-10011');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180423011153_InitialAzure')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180423011153_InitialAzure', N'2.0.2-rtm-10011');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180423014034_InitAzure11')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180423014034_InitAzure11', N'2.0.2-rtm-10011');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180423014136_InitAzure12')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180423014136_InitAzure12', N'2.0.2-rtm-10011');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180423014755_InitAzure2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180423014755_InitAzure2', N'2.0.2-rtm-10011');
END;

GO

