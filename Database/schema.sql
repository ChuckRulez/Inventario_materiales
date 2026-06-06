-- Crear base de datos
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'InventarioMateriales')
BEGIN
    CREATE DATABASE InventarioMateriales;
END
GO

-- Usar la base de datos
USE InventarioMateriales;
GO

-- Crear tabla de materiales
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Materiales')
BEGIN
    CREATE TABLE Materiales (
        ID INT PRIMARY KEY IDENTITY(1,1),
        Categoria NVARCHAR(100) NOT NULL,
        Descripcion NVARCHAR(500) NOT NULL,
        Numero_tipo NVARCHAR(50),
        Numero_pedido NVARCHAR(50),
        PVP DECIMAL(10, 2) NOT NULL,
        Descuento DECIMAL(5, 2) NOT NULL DEFAULT 0,
        Neto DECIMAL(10, 2) NOT NULL,
        UE INT NOT NULL DEFAULT 1,
        Neto_UE DECIMAL(10, 2) NOT NULL,
        Fecha_precio DATETIME NOT NULL DEFAULT GETDATE(),
        Fecha_creacion DATETIME NOT NULL DEFAULT GETDATE(),
        Fecha_actualizacion DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO

-- Crear índices para mejor rendimiento
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Categoria' AND object_id = OBJECT_ID('Materiales'))
BEGIN
    CREATE INDEX IX_Categoria ON Materiales(Categoria);
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Numero_pedido' AND object_id = OBJECT_ID('Materiales'))
BEGIN
    CREATE INDEX IX_Numero_pedido ON Materiales(Numero_pedido);
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Descripcion' AND object_id = OBJECT_ID('Materiales'))
BEGIN
    CREATE INDEX IX_Descripcion ON Materiales(Descripcion);
END
GO

-- Insertar datos de ejemplo
IF NOT EXISTS (SELECT * FROM Materiales)
BEGIN
    INSERT INTO Materiales (Categoria, Descripcion, Numero_tipo, Numero_pedido, PVP, Descuento, Neto, UE, Neto_UE, Fecha_precio)
    VALUES 
        ('Tornillos', 'Tornillo M6x20mm', 'M6', 'PED001', 0.50, 0, 0.50, 100, 50.00, GETDATE()),
        ('Tuberías', 'Tubería PVC 1 pulgada', 'PVC-1', 'PED002', 15.00, 5, 14.25, 10, 142.50, GETDATE()),
        ('Cables', 'Cable eléctrico 2.5mm rojo', 'ELC-2.5R', 'PED003', 0.75, 0, 0.75, 100, 75.00, GETDATE()),
        ('Tuercas', 'Tuerca M6', 'M6', 'PED004', 0.30, 0, 0.30, 100, 30.00, GETDATE()),
        ('Arandelas', 'Arandela M6', 'M6', 'PED005', 0.20, 0, 0.20, 100, 20.00, GETDATE());
END
GO

PRINT 'Base de datos y tabla creadas correctamente.';
