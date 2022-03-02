create database MusalaGatewayDb;
go
use MusalaGatewayDb;
go




IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type IN ('U'))
	DROP TABLE [dbo].[__EFMigrationsHistory]
GO

CREATE TABLE [dbo].[__EFMigrationsHistory] (
  [MigrationId] nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [ProductVersion] nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[__EFMigrationsHistory] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of __EFMigrationsHistory
-- ----------------------------
INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220222021151_Initial', N'5.0.1')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220222023157_FixedRelationshipBetweenModels', N'5.0.1')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220222024922_SeedingGatewayData', N'5.0.1')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220222025605_SeedingPeripheralDeviceData', N'5.0.1')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220222030913_SeedingPeripheralDeviceData', N'5.0.1')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220222031122_SeedingPeripheralDeviceData', N'5.0.1')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220222031425_SeedingPeripheralDeviceData', N'5.0.1')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220222031734_SeedingPeripheralDeviceData', N'5.0.1')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220222032001_GatewayData', N'5.0.1')
GO


-- ----------------------------
-- Table structure for Gateways
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Gateways]') AND type IN ('U'))
	DROP TABLE [dbo].[Gateways]
GO

CREATE TABLE [dbo].[Gateways] (
  [SerialNumber] uniqueidentifier  NOT NULL,
  [Name] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [IpAddress] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Gateways] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Gateways
-- ----------------------------
INSERT INTO [dbo].[Gateways] ([SerialNumber], [Name], [IpAddress]) VALUES (N'7D50A06B-2872-41CA-550F-08D9F67441AE', N'Gateway-C', N'1.1.1.0')
GO

INSERT INTO [dbo].[Gateways] ([SerialNumber], [Name], [IpAddress]) VALUES (N'6C69A7FA-57CA-4741-F01E-08D9F6768E6A', N'Gateway-D', N'124.23.2.1')
GO

INSERT INTO [dbo].[Gateways] ([SerialNumber], [Name], [IpAddress]) VALUES (N'249739CD-B14C-4E86-F01F-08D9F6768E6A', N'Gateway-E', N'255.23.2.2')
GO


-- ----------------------------
-- Table structure for PeripheralDevices
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[PeripheralDevices]') AND type IN ('U'))
	DROP TABLE [dbo].[PeripheralDevices]
GO

CREATE TABLE [dbo].[PeripheralDevices] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Vendor] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [DateCreated] datetime2(7)  NOT NULL,
  [Status] bit  NOT NULL,
  [GatewayId] uniqueidentifier DEFAULT ('00000000-0000-0000-0000-000000000000') NOT NULL
)
GO

ALTER TABLE [dbo].[PeripheralDevices] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of PeripheralDevices
-- ----------------------------
SET IDENTITY_INSERT [dbo].[PeripheralDevices] ON
GO

INSERT INTO [dbo].[PeripheralDevices] ([Id], [Vendor], [DateCreated], [Status], [GatewayId]) VALUES (N'39', N'a', N'2022-02-16 00:00:00.0000000', N'0', N'6C69A7FA-57CA-4741-F01E-08D9F6768E6A')
GO

INSERT INTO [dbo].[PeripheralDevices] ([Id], [Vendor], [DateCreated], [Status], [GatewayId]) VALUES (N'40', N'as', N'2022-02-24 00:00:00.0000000', N'0', N'6C69A7FA-57CA-4741-F01E-08D9F6768E6A')
GO

INSERT INTO [dbo].[PeripheralDevices] ([Id], [Vendor], [DateCreated], [Status], [GatewayId]) VALUES (N'54', N'asd', N'2022-02-09 00:00:00.0000000', N'0', N'249739CD-B14C-4E86-F01F-08D9F6768E6A')
GO

INSERT INTO [dbo].[PeripheralDevices] ([Id], [Vendor], [DateCreated], [Status], [GatewayId]) VALUES (N'57', N'SDADA', N'2022-02-15 00:00:00.0000000', N'0', N'6C69A7FA-57CA-4741-F01E-08D9F6768E6A')
GO

SET IDENTITY_INSERT [dbo].[PeripheralDevices] OFF
GO


-- ----------------------------
-- Primary Key structure for table __EFMigrationsHistory
-- ----------------------------
ALTER TABLE [dbo].[__EFMigrationsHistory] ADD CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Gateways
-- ----------------------------
ALTER TABLE [dbo].[Gateways] ADD CONSTRAINT [PK_Gateways] PRIMARY KEY CLUSTERED ([SerialNumber])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for PeripheralDevices
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[PeripheralDevices]', RESEED, 59)
GO


-- ----------------------------
-- Indexes structure for table PeripheralDevices
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_PeripheralDevices_GatewayId]
ON [dbo].[PeripheralDevices] (
  [GatewayId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table PeripheralDevices
-- ----------------------------
ALTER TABLE [dbo].[PeripheralDevices] ADD CONSTRAINT [PK_PeripheralDevices] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table PeripheralDevices
-- ----------------------------
ALTER TABLE [dbo].[PeripheralDevices] ADD CONSTRAINT [FK_PeripheralDevices_Gateways_GatewayId] FOREIGN KEY ([GatewayId]) REFERENCES [dbo].[Gateways] ([SerialNumber]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


