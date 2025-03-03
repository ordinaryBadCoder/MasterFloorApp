USE [master]
GO
/****** Object:  Database [MasterFloor]    Script Date: 09.02.2025 22:20:43 ******/
CREATE DATABASE [MasterFloor]

GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MasterFloor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MasterFloor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MasterFloor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MasterFloor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MasterFloor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MasterFloor] SET ARITHABORT OFF 
GO
ALTER DATABASE [MasterFloor] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MasterFloor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MasterFloor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MasterFloor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MasterFloor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MasterFloor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MasterFloor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MasterFloor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MasterFloor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MasterFloor] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MasterFloor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MasterFloor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MasterFloor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MasterFloor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MasterFloor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MasterFloor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MasterFloor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MasterFloor] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MasterFloor] SET  MULTI_USER 
GO
ALTER DATABASE [MasterFloor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MasterFloor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MasterFloor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MasterFloor] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MasterFloor] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MasterFloor] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MasterFloor] SET QUERY_STORE = ON
GO
ALTER DATABASE [MasterFloor] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200)
GO
USE [MasterFloor]
GO
/****** Object:  Table [dbo].[MaterialType]    Script Date: 09.02.2025 22:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[typeMaterial] [varchar](50) NULL,
	[defectRate] [float] NULL,
 CONSTRAINT [PK_MaterialType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartnerProduct]    Script Date: 09.02.2025 22:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartnerProduct](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idProduct] [int] NULL,
	[idPartner] [int] NULL,
	[quantity] [int] NULL,
	[dateSale] [date] NULL,
 CONSTRAINT [PK_PartnerProduct] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partners]    Script Date: 09.02.2025 22:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partners](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPartnerType] [int] NULL,
	[namePartner] [varchar](50) NULL,
	[directorName] [varchar](255) NULL,
	[email] [varchar](100) NULL,
	[phone] [varchar](100) NULL,
	[address] [varchar](255) NULL,
	[inn] [varchar](20) NULL,
	[rate] [int] NULL,
 CONSTRAINT [PK_Partners] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartnerType]    Script Date: 09.02.2025 22:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartnerType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[typePartner] [varchar](50) NULL,
 CONSTRAINT [PK_PartnerType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 09.02.2025 22:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idTypeProduct] [int] NULL,
	[nameProduct] [varchar](255) NULL,
	[articleNumber] [varchar](20) NULL,
	[minCost] [float] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 09.02.2025 22:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[typeProduct] [varchar](50) NULL,
	[productTypeCoeff] [float] NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MaterialType] ON 
GO
INSERT [dbo].[MaterialType] ([id], [typeMaterial], [defectRate]) VALUES (1, N'Тип материала 1', 0.001)
GO
INSERT [dbo].[MaterialType] ([id], [typeMaterial], [defectRate]) VALUES (2, N'Тип материала 2', 0.0095)
GO
INSERT [dbo].[MaterialType] ([id], [typeMaterial], [defectRate]) VALUES (3, N'Тип материала 3', 0.0028)
GO
INSERT [dbo].[MaterialType] ([id], [typeMaterial], [defectRate]) VALUES (4, N'Тип материала 4', 0.0055)
GO
INSERT [dbo].[MaterialType] ([id], [typeMaterial], [defectRate]) VALUES (5, N'Тип материала 5', 0.0034)
GO
SET IDENTITY_INSERT [dbo].[MaterialType] OFF
GO
SET IDENTITY_INSERT [dbo].[PartnerProduct] ON 
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (1, 1, 1, 15500, CAST(N'2023-03-23' AS Date))
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (2, 3, 1, 12350, CAST(N'2023-12-18' AS Date))
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (3, 4, 1, 37400, CAST(N'2024-06-07' AS Date))
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (4, 2, 2, 35000, CAST(N'2022-12-02' AS Date))
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (5, 5, 2, 1250, CAST(N'2023-05-17' AS Date))
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (6, 3, 2, 1000, CAST(N'2024-06-07' AS Date))
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (7, 1, 2, 7550, CAST(N'2024-07-01' AS Date))
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (8, 1, 3, 7250, CAST(N'2023-01-22' AS Date))
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (9, 2, 3, 2500, CAST(N'2024-07-05' AS Date))
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (10, 4, 4, 59050, CAST(N'2023-03-20' AS Date))
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (11, 3, 4, 37200, CAST(N'2024-03-12' AS Date))
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (12, 5, 4, 4500, CAST(N'2024-05-14' AS Date))
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (13, 3, 5, 50000, CAST(N'2023-09-19' AS Date))
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (14, 4, 5, 670000, CAST(N'2023-11-10' AS Date))
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (15, 1, 5, 35000, CAST(N'2024-04-15' AS Date))
GO
INSERT [dbo].[PartnerProduct] ([id], [idProduct], [idPartner], [quantity], [dateSale]) VALUES (16, 2, 5, 25000, CAST(N'2024-06-12' AS Date))
GO
SET IDENTITY_INSERT [dbo].[PartnerProduct] OFF
GO
SET IDENTITY_INSERT [dbo].[Partners] ON 
GO
INSERT [dbo].[Partners] ([id], [idPartnerType], [namePartner], [directorName], [email], [phone], [address], [inn], [rate]) VALUES (1, 1, N'База Строитель', N'Иванова Александра Ивановна', N'aleksandraivanova@ml.ru', N'493 123 45 67', N'652050, Кемеровская область, город Юрга, ул. Лесная, 15', N'2222455179', 7)
GO
INSERT [dbo].[Partners] ([id], [idPartnerType], [namePartner], [directorName], [email], [phone], [address], [inn], [rate]) VALUES (2, 2, N'Паркет 29', N'Петров Василий Петрович', N'vppetrov@vl.ru', N'987 123 56 78', N'164500, Архангельская область, город Северодвинск, ул. Строителей, 18', N'3333888520', 7)
GO
INSERT [dbo].[Partners] ([id], [idPartnerType], [namePartner], [directorName], [email], [phone], [address], [inn], [rate]) VALUES (3, 3, N'Стройсервис', N'Соловьев Андрей Николаевич', N'ansolovev@st.ru', N'812 223 32 00', N'188910, Ленинградская область, город Приморск, ул. Парковая, 21', N'4440391035', 7)
GO
INSERT [dbo].[Partners] ([id], [idPartnerType], [namePartner], [directorName], [email], [phone], [address], [inn], [rate]) VALUES (4, 4, N'Ремонт и отделка', N'Воробьева Екатерина Валерьевна', N'ekaterina.vorobeva@ml.ru', N'444 222 33 11', N'143960, Московская область, город Реутов, ул. Свободы, 51', N'1111520857', 5)
GO
INSERT [dbo].[Partners] ([id], [idPartnerType], [namePartner], [directorName], [email], [phone], [address], [inn], [rate]) VALUES (5, 1, N'МонтажПро', N'Степанов Степан Сергеевич', N'stepanov@stepan.ru', N'912 888 33 33', N'309500, Белгородская область, город Старый Оскол, ул. Рабочая, 122', N'5552431140', 10)
GO
SET IDENTITY_INSERT [dbo].[Partners] OFF
GO
SET IDENTITY_INSERT [dbo].[PartnerType] ON 
GO
INSERT [dbo].[PartnerType] ([id], [typePartner]) VALUES (1, N'ЗАО')
GO
INSERT [dbo].[PartnerType] ([id], [typePartner]) VALUES (2, N'ООО')
GO
INSERT [dbo].[PartnerType] ([id], [typePartner]) VALUES (3, N'ПАО')
GO
INSERT [dbo].[PartnerType] ([id], [typePartner]) VALUES (4, N'ОАО')
GO
SET IDENTITY_INSERT [dbo].[PartnerType] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([id], [idTypeProduct], [nameProduct], [articleNumber], [minCost]) VALUES (1, 3, N'Паркетная доска Ясень темный однополосная 14 мм', N'8758385', 4456.9)
GO
INSERT [dbo].[Product] ([id], [idTypeProduct], [nameProduct], [articleNumber], [minCost]) VALUES (2, 3, N'Инженерная доска Дуб Французская елка однополосная 12 мм', N'8858958', 7330.99)
GO
INSERT [dbo].[Product] ([id], [idTypeProduct], [nameProduct], [articleNumber], [minCost]) VALUES (3, 1, N'Ламинат Дуб дымчато-белый 33 класс 12 мм', N'7750282', 1799.33)
GO
INSERT [dbo].[Product] ([id], [idTypeProduct], [nameProduct], [articleNumber], [minCost]) VALUES (4, 1, N'Ламинат Дуб серый 32 класс 8 мм с фаской', N'7028748', 3890.41)
GO
INSERT [dbo].[Product] ([id], [idTypeProduct], [nameProduct], [articleNumber], [minCost]) VALUES (5, 4, N'Пробковое напольное клеевое покрытие 32 класс 4 мм', N'5012543', 5450.59)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductType] ON 
GO
INSERT [dbo].[ProductType] ([id], [typeProduct], [productTypeCoeff]) VALUES (1, N'Ламинат', 2.35)
GO
INSERT [dbo].[ProductType] ([id], [typeProduct], [productTypeCoeff]) VALUES (2, N'Массивная доска', 5.15)
GO
INSERT [dbo].[ProductType] ([id], [typeProduct], [productTypeCoeff]) VALUES (3, N'Паркетная доска', 4.34)
GO
INSERT [dbo].[ProductType] ([id], [typeProduct], [productTypeCoeff]) VALUES (4, N'Пробковое покрытие', 1.5)
GO
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO
ALTER TABLE [dbo].[PartnerProduct]  WITH CHECK ADD  CONSTRAINT [FK_PartnerProduct_Partners] FOREIGN KEY([idPartner])
REFERENCES [dbo].[Partners] ([id])
GO
ALTER TABLE [dbo].[PartnerProduct] CHECK CONSTRAINT [FK_PartnerProduct_Partners]
GO
ALTER TABLE [dbo].[PartnerProduct]  WITH CHECK ADD  CONSTRAINT [FK_PartnerProduct_Product] FOREIGN KEY([idProduct])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[PartnerProduct] CHECK CONSTRAINT [FK_PartnerProduct_Product]
GO
ALTER TABLE [dbo].[Partners]  WITH CHECK ADD  CONSTRAINT [FK_Partners_PartnerType] FOREIGN KEY([idPartnerType])
REFERENCES [dbo].[PartnerType] ([id])
GO
ALTER TABLE [dbo].[Partners] CHECK CONSTRAINT [FK_Partners_PartnerType]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([idTypeProduct])
REFERENCES [dbo].[ProductType] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
USE [master]
GO
ALTER DATABASE [MasterFloor] SET  READ_WRITE 
GO
