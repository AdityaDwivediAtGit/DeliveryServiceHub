CREATE TABLE [dbo].[DeliveryResponses](
	[ResponseId] [int] IDENTITY(1,1) NOT NULL,
	[RequestId] [int] NOT NULL,
	[Provider] [nvarchar](50) NOT NULL,
	[Response] [nvarchar](max) NOT NULL,
	[ResponseDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ResponseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[DeliveryResponses]  WITH CHECK ADD FOREIGN KEY([RequestId])
REFERENCES [dbo].[DeliveryRequests] ([RequestId])
GO
ALTER TABLE [dbo].[DeliveryResponses] ADD  DEFAULT (getdate()) FOR [ResponseDate]