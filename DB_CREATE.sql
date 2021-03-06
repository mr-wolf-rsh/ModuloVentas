USE [db_ventas]
GO
/****** Object:  StoredProcedure [dbo].[usp_Registrar_DetalleFactura_Un_Producto_Minimo]    Script Date: 21/07/2020 17:42:37 ******/
DROP PROCEDURE [dbo].[usp_Registrar_DetalleFactura_Un_Producto_Minimo]
GO
/****** Object:  StoredProcedure [dbo].[usp_Listar_Vendedores_Ingreso_2019]    Script Date: 21/07/2020 17:42:37 ******/
DROP PROCEDURE [dbo].[usp_Listar_Vendedores_Ingreso_2019]
GO
/****** Object:  StoredProcedure [dbo].[usp_Listar_Productos]    Script Date: 21/07/2020 17:42:37 ******/
DROP PROCEDURE [dbo].[usp_Listar_Productos]
GO
/****** Object:  StoredProcedure [dbo].[usp_Listar_Facturas_Por_Importe]    Script Date: 21/07/2020 17:42:37 ******/
DROP PROCEDURE [dbo].[usp_Listar_Facturas_Por_Importe]
GO
/****** Object:  StoredProcedure [dbo].[usp_Listar_Clientes_Categoria_A_Sin_Factura]    Script Date: 21/07/2020 17:42:37 ******/
DROP PROCEDURE [dbo].[usp_Listar_Clientes_Categoria_A_Sin_Factura]
GO
ALTER TABLE [dbo].[Factura] DROP CONSTRAINT [FK_Factura_Vendedor]
GO
ALTER TABLE [dbo].[Factura] DROP CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [dbo].[DetalleFactura] DROP CONSTRAINT [FK_DetalleFactura_Producto]
GO
ALTER TABLE [dbo].[DetalleFactura] DROP CONSTRAINT [FK_DetalleFactura_Factura]
GO
/****** Object:  Table [dbo].[Vendedor]    Script Date: 21/07/2020 17:42:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vendedor]') AND type in (N'U'))
DROP TABLE [dbo].[Vendedor]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 21/07/2020 17:42:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Producto]') AND type in (N'U'))
DROP TABLE [dbo].[Producto]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 21/07/2020 17:42:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Factura]') AND type in (N'U'))
DROP TABLE [dbo].[Factura]
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 21/07/2020 17:42:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DetalleFactura]') AND type in (N'U'))
DROP TABLE [dbo].[DetalleFactura]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 21/07/2020 17:42:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente]') AND type in (N'U'))
DROP TABLE [dbo].[Cliente]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 21/07/2020 17:42:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Nic] [varchar](12) NOT NULL,
	[Categoria] [char](1) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 21/07/2020 17:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[DetalleFacturaId] [int] IDENTITY(1,1) NOT NULL,
	[FacturaId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 5) NOT NULL,
 CONSTRAINT [PK_DetalleFactura] PRIMARY KEY CLUSTERED 
(
	[DetalleFacturaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 21/07/2020 17:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[FacturaId] [int] IDENTITY(1,1) NOT NULL,
	[Serie] [varchar](3) NOT NULL,
	[Codigo] [varchar](5) NOT NULL,
	[VendedorId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Moneda] [char](3) NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[FacturaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 21/07/2020 17:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ProductoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[PrecioUnitario] [decimal](18, 5) NOT NULL,
	[Categoria] [char](2) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendedor]    Script Date: 21/07/2020 17:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendedor](
	[VendedorId] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Dni] [char](8) NOT NULL,
	[FechaIngreso] [date] NOT NULL,
 CONSTRAINT [PK_Vendedor] PRIMARY KEY CLUSTERED 
(
	[VendedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Factura] FOREIGN KEY([FacturaId])
REFERENCES [dbo].[Factura] ([FacturaId])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Factura]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([ProductoId])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Producto]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Vendedor] FOREIGN KEY([VendedorId])
REFERENCES [dbo].[Vendedor] ([VendedorId])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Vendedor]
GO
/****** Object:  StoredProcedure [dbo].[usp_Listar_Clientes_Categoria_A_Sin_Factura]    Script Date: 21/07/2020 17:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Listar_Clientes_Categoria_A_Sin_Factura]
AS
BEGIN
	SELECT Nombres, Apellidos, Nic, Categoria FROM Cliente
	LEFT JOIN Factura ON Cliente.ClienteId = Factura.ClienteId
	WHERE Factura.ClienteId IS NULL AND Cliente.Categoria = 'A';
END;

GO
/****** Object:  StoredProcedure [dbo].[usp_Listar_Facturas_Por_Importe]    Script Date: 21/07/2020 17:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Listar_Facturas_Por_Importe]
AS
BEGIN
	SELECT Cliente.Nombres as CNombres, Cliente.Apellidos as CApellidos, Cliente.Nic, Cliente.Categoria,
	Vendedor.Nombres as VNombres, Vendedor.Apellidos as VApellidos, Vendedor.Dni, Vendedor.FechaIngreso,
	(DetalleFactura.Cantidad * DetalleFactura.PrecioUnitario) as Total
	FROM (((Factura
	INNER JOIN Cliente ON Factura.ClienteId = Cliente.ClienteId)
	INNER JOIN Vendedor ON Factura.VendedorId = Vendedor.VendedorId)
	INNER JOIN DetalleFactura ON Factura.FacturaId = DetalleFactura.FacturaId)
	ORDER BY Total DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Listar_Productos]    Script Date: 21/07/2020 17:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Listar_Productos]
AS
BEGIN
	SELECT * FROM Producto;
END;

GO
/****** Object:  StoredProcedure [dbo].[usp_Listar_Vendedores_Ingreso_2019]    Script Date: 21/07/2020 17:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Listar_Vendedores_Ingreso_2019]
AS
BEGIN
	SELECT Nombres, Apellidos, Dni, FechaIngreso FROM Vendedor WHERE (SELECT YEAR(FechaIngreso)) = 2019;
END;

GO
/****** Object:  StoredProcedure [dbo].[usp_Registrar_DetalleFactura_Un_Producto_Minimo]    Script Date: 21/07/2020 17:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Registrar_DetalleFactura_Un_Producto_Minimo]
	@FacturaId int,
	@ProductoId int,
	@Cantidad int,
	@PrecioUnitario decimal(18,5)
AS
BEGIN
	IF @ProductoId IS NOT NULL OR @Cantidad > 0
		INSERT INTO DetalleFactura (FacturaId, ProductoId, Cantidad, PrecioUnitario)
		VALUES (@FacturaId, @ProductoId, @Cantidad, @PrecioUnitario);
	ELSE
		THROW 51000, 'Debe haber un producto mínimo y cantidad mayor a cero.', 1;
END;
GO
