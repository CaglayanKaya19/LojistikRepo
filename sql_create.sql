CREATE DATABASE A_Logistics
GO
USE A_Logistics
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_external_order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_no] [nvarchar](30) NULL,
	[create_date] [datetime] NULL,
	[shipment_poit] [nvarchar](50) NULL,
	[receiver] [nvarchar](120) NULL,
	[contact_phone] [nvarchar](15) NULL,
	[order_count] [int] NULL,
	[product_name] [nvarchar](80) NULL,
	[product_barcode] [nvarchar](150) NULL,
	[stock_count] [int] NULL,
 CONSTRAINT [PK_tbl_external_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE A_Logistics
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_order_delivey](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ORDER_ID] [int] NULL,
	[delivery_status] [smallint] NOT NULL,
	[delivery_plate] [nvarchar](50) NULL,
	[delivery_person] [nvarchar](150) NULL,
	[create_date] [datetime] NOT NULL,
	[update_date] [datetime] NULL,
 CONSTRAINT [PK_tbl_delivey] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbl_order_delivey] ADD  CONSTRAINT [DF_tbl_delivey_delivery_status]  DEFAULT ((0)) FOR [delivery_status]
GO

ALTER TABLE [dbo].[tbl_order_delivey] ADD  CONSTRAINT [DF_tbl_order_delivey_create_date]  DEFAULT (getdate()) FOR [create_date]
GO

ALTER TABLE [dbo].[tbl_order_delivey]  WITH CHECK ADD  CONSTRAINT [FK_tbl_order_delivey_tbl_external_order] FOREIGN KEY([ORDER_ID])
REFERENCES [dbo].[tbl_external_order] ([id])
GO

ALTER TABLE [dbo].[tbl_order_delivey] CHECK CONSTRAINT [FK_tbl_order_delivey_tbl_external_order]
GO
CREATE DATABASE B_Logistics
GO
USE B_Logistics
GO
/****** Object:  Table [dbo].[tbl_order]    Script Date: 8/1/2022 2:30:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_no] [nvarchar](30) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[shipment_poit] [nvarchar](50) NULL,
	[receiver] [nvarchar](120) NOT NULL,
	[contact_phone] [nvarchar](15) NOT NULL,
	[PRODUCT_ID] [int] NOT NULL,
	[order_count] [int] NOT NULL,
	[order_transfer_status] [smallint] NOT NULL,
	[order_transfer_status_update_date] [datetime] NULL,
 CONSTRAINT [PK_tbl_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_name] [nvarchar](80) NOT NULL,
	[product_barcode] [nvarchar](150) NOT NULL,
	[stock_count] [int] NOT NULL,
	[create_date] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_order] ADD  CONSTRAINT [DF_tbl_order_create_date]  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[tbl_order] ADD  CONSTRAINT [DF_tbl_order_status]  DEFAULT ((0)) FOR [order_transfer_status]
GO
ALTER TABLE [dbo].[tbl_product] ADD  CONSTRAINT [DF_tbl_product_create_date]  DEFAULT (getdate()) FOR [create_date]
GO
ALTER TABLE [dbo].[tbl_order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_order_tbl_product] FOREIGN KEY([PRODUCT_ID])
REFERENCES [dbo].[tbl_product] ([id])
GO
ALTER TABLE [dbo].[tbl_order] CHECK CONSTRAINT [FK_tbl_order_tbl_product]
GO

USE B_Logistics
GO

INSERT [dbo].[tbl_product] ([product_name], [product_barcode], [stock_count], [create_date]) VALUES (N'Kalem', N'KLM001123', 65, CAST(N'2022-07-27T20:16:50.753' AS DateTime))
INSERT [dbo].[tbl_product] ([product_name], [product_barcode], [stock_count], [create_date]) VALUES (N'Kitap', N'KTP001344', 42, CAST(N'2022-07-27T20:17:05.457' AS DateTime))
INSERT [dbo].[tbl_product] ([product_name], [product_barcode], [stock_count], [create_date]) VALUES (N'Çanta', N'CNT001641', 34, CAST(N'2022-07-27T20:17:26.020' AS DateTime))
INSERT [dbo].[tbl_product] ([product_name], [product_barcode], [stock_count], [create_date]) VALUES (N'Defter', N'DFT003412', 22, CAST(N'2022-07-27T20:17:55.520' AS DateTime))
GO
INSERT [dbo].[tbl_order] ( [order_no], [create_date], [shipment_poit], [receiver], [contact_phone], [PRODUCT_ID], [order_count], [order_transfer_status], [order_transfer_status_update_date]) VALUES (N'SPR001', GETDATE()-1, N'Adrese Teslimat', N'Çağlayan Kaya', N'5367873823', 1, 5, 0, NULL)
INSERT [dbo].[tbl_order] ( [order_no], [create_date], [shipment_poit], [receiver], [contact_phone], [PRODUCT_ID], [order_count], [order_transfer_status], [order_transfer_status_update_date]) VALUES (N'SPR002', GETDATE()-1, N'Adrese Teslimat', N'Emre Kaya', N'5367873823', 2, 10, 0, NULL)
INSERT [dbo].[tbl_order] ( [order_no], [create_date], [shipment_poit], [receiver], [contact_phone], [PRODUCT_ID], [order_count], [order_transfer_status], [order_transfer_status_update_date]) VALUES (N'SPR003', GETDATE()-1, N'Adrese Teslimat', N'İcabi Kaya', N'5367873823', 3, 9, 0, NULL)
GO

