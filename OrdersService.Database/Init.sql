SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([Id], [CreationTimestamp], [DisplayId], [Price], [CustomerName], [Address]) VALUES (1, CAST(N'2018-03-28T09:40:52.4000000+00:00' AS DateTimeOffset), N'id 1', 1.0000, N'name 1', N'address 1')
GO
INSERT [dbo].[Orders] ([Id], [CreationTimestamp], [DisplayId], [Price], [CustomerName], [Address]) VALUES (2, CAST(N'2018-03-28T09:41:00.5600000+00:00' AS DateTimeOffset), N'id 2', 2.0000, N'name 2', N'address 2')
GO
INSERT [dbo].[Orders] ([Id], [CreationTimestamp], [DisplayId], [Price], [CustomerName], [Address]) VALUES (3, CAST(N'2018-03-28T09:41:09.8233333+00:00' AS DateTimeOffset), N'id 3', 3.0000, N'name 3', N'address 3')
GO
INSERT [dbo].[Orders] ([Id], [CreationTimestamp], [DisplayId], [Price], [CustomerName], [Address]) VALUES (4, CAST(N'2018-03-28T09:41:21.8766667+00:00' AS DateTimeOffset), N'id 4', 4.0000, N'name 4', N'address 4')
GO
INSERT [dbo].[Orders] ([Id], [CreationTimestamp], [DisplayId], [Price], [CustomerName], [Address]) VALUES (5, CAST(N'2018-03-28T09:41:44.5900000+00:00' AS DateTimeOffset), N'id 5', 5.0000, N'name 5', N'address 4')
GO
INSERT [dbo].[Orders] ([Id], [CreationTimestamp], [DisplayId], [Price], [CustomerName], [Address]) VALUES (6, CAST(N'2018-03-28T09:41:56.5466667+00:00' AS DateTimeOffset), N'id 6', 6.0000, N'name 6', N'address 6')
GO
INSERT [dbo].[Orders] ([Id], [CreationTimestamp], [DisplayId], [Price], [CustomerName], [Address]) VALUES (7, CAST(N'2018-03-28T09:42:07.4866667+00:00' AS DateTimeOffset), N'id 7', 7.0000, N'name 7', N'address 7')
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
