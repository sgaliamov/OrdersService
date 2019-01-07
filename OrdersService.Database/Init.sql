INSERT [dbo].[Orders] ([CreationTimestamp], [OrderId], [Price], [CustomerName], [PostCode], [Number], [Street], [City], [Country], [Phone]) VALUES 
    (CAST(N'2018-03-28T09:40:52' AS DateTimeOffset), 'SAL100756', 10.0000, N'name 1', '1032AB', 13, N'Street', N'Amsterdam', N'The Netherlands', '0123456789'),
    (CAST(N'2018-03-28T09:41:00' AS DateTimeOffset), 'SAL1003221', 2.0000, N'name 2', '2032AB', NULL, N'Street', N'Amsterdam', N'The Netherlands', NULL),
    (CAST(N'2018-03-28T09:41:09' AS DateTimeOffset), 'SAL1005239', 3.0000, N'name 3', '3032AB', 15, N'Street', N'Amsterdam', N'The Netherlands', '0123456789'),
    (CAST(N'2018-03-28T09:41:21' AS DateTimeOffset), 'SAL1000001', 4.0000, N'name 4', '4032AB', 16, N'Street', N'Amsterdam', N'The Netherlands', '0123456789'),
    (CAST(N'2018-03-28T09:41:44' AS DateTimeOffset), 'SAL1000002', 5.0000, N'name 5', '5032AB', 17, N'Street', N'Amsterdam', N'The Netherlands', NULL),
    (CAST(N'2018-03-28T09:41:56' AS DateTimeOffset), 'SAL1000003', 6.0000, N'name 6', '6032AB', 18, N'Street', N'Amsterdam', N'The Netherlands', NULL),
    (CAST(N'2018-03-28T09:42:07' AS DateTimeOffset), 'SAL1000004', 7.0000, N'name 7', '7032AB', NULL, N'Street', N'Amsterdam', N'The Netherlands', '0123456789')
GO
