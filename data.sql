USE [BusTimetable]
GO
SET IDENTITY_INSERT [dbo].[Routes] ON 

INSERT [dbo].[Routes] ([Id], [RouteName], [RouteColor]) VALUES (5, N'Kamenjar-Crvena česma', N'#4287f5')
INSERT [dbo].[Routes] ([Id], [RouteName], [RouteColor]) VALUES (6, N'Laćarak-Kuper-Mala Bosna', N'#57a12a')
INSERT [dbo].[Routes] ([Id], [RouteName], [RouteColor]) VALUES (7, N'Laćarak-Industrijska zona-Groblje', N'#b32e2e')
SET IDENTITY_INSERT [dbo].[Routes] OFF
GO
SET IDENTITY_INSERT [dbo].[Stops] ON 

INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (7, N'Stari most', 44.9733266395123, 19.5985337094836)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (8, N'KPZ', 44.9928598410139, 19.6102496756179)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (9, N'Malta', 44.9705088283079, 19.6354904926363)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (10, N'Bolnica', 44.97234603268, 19.6070807994653)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (11, N'Glavna stanica', 44.981754930056, 19.614005517108)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (12, N'SDK', 44.9720959091366, 19.6108558729326)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (13, N'Stelina', 44.9719976372496, 19.614026005402)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (14, N'Posta', 44.9691527398884, 19.608675632226)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (15, N'Lipa', 44.9756878368478, 19.5948411114508)
INSERT [dbo].[Stops] ([Id], [StopName], [StopLat], [StopLon]) VALUES (16, N'Gimnazija', 44.9683959952577, 19.6056577732654)
SET IDENTITY_INSERT [dbo].[Stops] OFF
GO
SET IDENTITY_INSERT [dbo].[RouteStops] ON 

INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (4, 5, 0, 7, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (5, 5, 0, 8, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (6, 5, 0, 9, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (7, 5, 0, 10, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (8, 5, 0, 11, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (9, 5, 0, 12, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (10, 5, 0, 13, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (11, 6, 0, 14, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (12, 6, 0, 15, 0, 0)
INSERT [dbo].[RouteStops] ([Id], [RouteId], [Rbr], [StopId], [TimeInterval], [MetarDistance]) VALUES (13, 6, 0, 16, 0, 0)
SET IDENTITY_INSERT [dbo].[RouteStops] OFF
GO
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator]) VALUES (N'598f7adf-ea83-41eb-a31a-9a73130e1c94', N'string', N'string', N'YuuGS/i/YSAvfrWIUDc7qlEoq7IZF45y8Jl8wpDJudE=', CAST(N'2023-12-16T01:15:23.8622623' AS DateTime2), N'string2', N'STRING2', N'string2@gmail.com', N'STRING2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPle1VORQBrLCYmZfUrmco97b0CmqnIS4zFhB7KxzAJ9877W4P2vZubW162Vudvytg==', N'XG7ZINGULBNVARVQ4ZI7PYLX6PG6EZTQ', N'5ccd3af3-130b-4eac-8ed9-616e5bf7e1f3', N'string', 0, 0, NULL, 1, 0, N'User')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [RefreshToken], [RefreshTokenExpiryTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator]) VALUES (N'd4d3d13c-295a-4a68-9a69-33b3ddb78c97', N'string', N'string', N'LxpzU93+Ia4YgAf7MoviNIKkTKXjo5h+kAQvE2K87x4=', CAST(N'2023-12-17T21:24:40.5460228' AS DateTime2), N'string1', N'STRING1', N'string1@gmail.com', N'STRING1@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAECM/BQjmzxeZ/2e1y6yunDfjG/qXNVEZyhiMTmVh576HxyhzJoAgwWtVlGRvrNsFfA==', N'HIO4C7JOLTQZME2WFU3YGMRSNAINLRDE', N'c1d67c9f-bbfc-4c1f-a0d0-e3d4acca2150', N'string', 0, 0, NULL, 1, 0, N'User')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3854932d-83b4-46a3-8cf9-7d068eeca695', N'Manager', N'MANAGER', N'aa3526f2-4053-4837-8ea8-ca06d27af69d')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'58cdeabc-dbb2-499b-8c74-5b7c56298fce', N'User', N'USER', N'012a607a-88dc-4dbb-83ad-07cfc8fef12a')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'cbbab2a8-ed77-439c-98ed-7ebb86fa68c3', N'Admin', N'ADMIN', N'be1ecfa9-fb78-4eb2-8098-a0161d6365b0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'598f7adf-ea83-41eb-a31a-9a73130e1c94', N'58cdeabc-dbb2-499b-8c74-5b7c56298fce')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231204170229_INIT', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231204171215_Auth', N'6.0.25')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231204175239_Auth2', N'6.0.25')
GO
