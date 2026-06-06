# Inventario de Materiales

Aplicación de escritorio Windows Forms en C# para gestionar un inventario de materiales con SQL Server Express.

## 🎯 Características

- ✅ CRUD completo (Crear, Leer, Actualizar, Eliminar)
- ✅ Búsqueda avanzada por ID, Categoría y Número de Pedido
- ✅ Interfaz gráfica intuitiva con DataGridView
- ✅ Base de datos SQL Server Express
- ✅ Entity Framework Core para acceso a datos
- ✅ Validación de datos
- ✅ Gestión de errores

## 📋 Campos del Inventario

| Campo | Tipo | Descripción |
|-------|------|-------------|
| ID | int | Identificador único (auto-incremento) |
| Categoria | string | Categoría del material |
| Descripcion | string | Descripción del material |
| Numero_tipo | string | Número de tipo |
| Numero_pedido | string | Número de pedido |
| PVP | decimal | Precio de venta al público |
| Descuento | decimal | Porcentaje de descuento |
| Neto | decimal | Precio neto |
| UE | int | Unidad de Empaque |
| Neto_UE | decimal | Precio neto por unidad de empaque |
| Fecha_precio | datetime | Fecha del precio |

## 📦 Requisitos

- Windows 10 o superior
- .NET 6.0 o superior
- SQL Server Express 2019 o superior
- Visual Studio 2022 o Visual Studio Code (recomendado)

## 🚀 Instalación

### 1. Clonar el repositorio

```bash
git clone https://github.com/ChuckRulez/Inventario_materiales.git
cd Inventario_materiales
```

### 2. Crear la base de datos

Abre SQL Server Management Studio y ejecuta el script `Database/schema.sql`:

```bash
sqlcmd -S .\SQLEXPRESS -U sa -P <tu_contraseña> -i Database\schema.sql
```

O manualmente en SQL Server Management Studio:
- Conecta a tu instancia de SQL Server Express
- Abre el archivo `Database/schema.sql`
- Ejecuta el script (F5)

### 3. Actualizar la conexión

Edita `src/appsettings.json` y actualiza la cadena de conexión según tu configuración:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=InventarioMateriales;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

**Opciones de conexión:**
- `Server=.\SQLEXPRESS` - SQL Server Express local
- `Server=NOMBRE_PC\SQLEXPRESS` - SQL Server Express en otra máquina
- `Server=.;Database=InventarioMateriales;User Id=sa;Password=tu_contraseña;` - Con usuario y contraseña

### 4. Restaurar dependencias y compilar

```bash
dotnet restore
dotnet build
```

### 5. Ejecutar la aplicación

```bash
dotnet run
```

## 💻 Uso

1. **Agregar Material**
   - Completa todos los campos en el formulario
   - Haz clic en "Agregar"
   - El material aparecerá en la tabla

2. **Ver Materiales**
   - Se cargan automáticamente en el DataGridView
   - Puedes desplazarte por la tabla

3. **Actualizar Material**
   - Selecciona una fila de la tabla
   - Modifica los datos en el formulario
   - Haz clic en "Actualizar"

4. **Eliminar Material**
   - Selecciona una fila de la tabla
   - Haz clic en "Eliminar"
   - Confirma la eliminación

5. **Buscar Material**
   - Usa la barra de búsqueda para filtrar por:
     - ID
     - Categoría
     - Número de Pedido

## 📂 Estructura del Proyecto

```
Inventario_materiales/
├── src/
│   ├── Models/
│   │   └── Material.cs                    # Modelo de datos
│   ├── Data/
│   │   └── InventarioContext.cs           # Contexto EF Core
│   ├── Services/
│   │   └── MaterialService.cs             # Lógica de negocio
│   ├── Forms/
│   │   ├── MainForm.cs                    # Formulario principal
│   │   ├── MainForm.Designer.cs           # Diseño generado
│   │   └── MainForm.resx                  # Recursos
│   ├── Program.cs                         # Punto de entrada
│   ├── appsettings.json                   # Configuración
│   └── InventarioMateriales.csproj        # Archivo de proyecto
├── Database/
│   └── schema.sql                         # Script SQL
├── .gitignore
├── README.md
└── LICENSE
```

## 🔧 Tecnologías Utilizadas

- **Lenguaje**: C# .NET 6.0
- **UI**: Windows Forms
- **Base de Datos**: SQL Server Express
- **ORM**: Entity Framework Core 6.0
- **Validación**: Fluent Validation

## 📝 Licencia

Este proyecto es de código abierto bajo la licencia MIT.

## 👨‍💻 Autor

ChuckRulez

## 🐛 Reporte de Problemas

Si encuentras problemas o bugs, por favor abre un [issue](https://github.com/ChuckRulez/Inventario_materiales/issues) en el repositorio.

## 💡 Sugerencias de Mejora

Las sugerencias y contribuciones son bienvenidas. Por favor:
1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

---

**Versión**: 1.0.0  
**Última actualización**: 2026-06-06
