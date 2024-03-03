CREATE TABLE [dbo].[DeliveryRequests](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[ShopId] [int] NOT NULL,
	[Items] [nvarchar](max) NOT NULL,
	[DeliveryPartner] [nvarchar](max) NOT NULL,
	[RequestDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[DeliveryRequests] ADD  DEFAULT (getdate()) FOR [RequestDate]