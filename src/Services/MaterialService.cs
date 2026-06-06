using Microsoft.EntityFrameworkCore;
using InventarioMateriales.Data;
using InventarioMateriales.Models;

namespace InventarioMateriales.Services
{
    /// <summary>
    /// Servicio para gestionar operaciones CRUD de materiales
    /// </summary>
    public class MaterialService
    {
        private readonly InventarioContext _context;

        public MaterialService(InventarioContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los materiales
        /// </summary>
        public async Task<List<Material>> GetAllMaterialesAsync()
        {
            try
            {
                return await _context.Materiales.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los materiales", ex);
            }
        }

        /// <summary>
        /// Obtiene un material por ID
        /// </summary>
        public async Task<Material?> GetMaterialByIdAsync(int id)
        {
            try
            {
                return await _context.Materiales.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el material con ID {id}", ex);
            }
        }

        /// <summary>
        /// Busca materiales por criterios
        /// </summary>
        public async Task<List<Material>> BuscarMaterialesAsync(string? categoria = null, string? numeroPedido = null, string? descripcion = null)
        {
            try
            {
                var query = _context.Materiales.AsQueryable();

                if (!string.IsNullOrEmpty(categoria))
                {
                    query = query.Where(m => m.Categoria.Contains(categoria));
                }

                if (!string.IsNullOrEmpty(numeroPedido))
                {
                    query = query.Where(m => m.Numero_pedido != null && m.Numero_pedido.Contains(numeroPedido));
                }

                if (!string.IsNullOrEmpty(descripcion))
                {
                    query = query.Where(m => m.Descripcion.Contains(descripcion));
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar materiales", ex);
            }
        }

        /// <summary>
        /// Crea un nuevo material
        /// </summary>
        public async Task<Material> CreateMaterialAsync(Material material)
        {
            try
            {
                ValidarMaterial(material);

                // Calcular neto si no está completo
                if (material.Neto <= 0)
                {
                    material.Neto = material.PVP - (material.PVP * material.Descuento / 100);
                }

                // Calcular neto por UE si no está completo
                if (material.Neto_UE <= 0)
                {
                    material.Neto_UE = material.Neto * material.UE;
                }

                _context.Materiales.Add(material);
                await _context.SaveChangesAsync();

                return material;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el material", ex);
            }
        }

        /// <summary>
        /// Actualiza un material existente
        /// </summary>
        public async Task<Material> UpdateMaterialAsync(Material material)
        {
            try
            {
                ValidarMaterial(material);

                var existingMaterial = await _context.Materiales.FindAsync(material.ID);
                if (existingMaterial == null)
                {
                    throw new Exception($"Material con ID {material.ID} no encontrado");
                }

                // Actualizar propiedades
                existingMaterial.Categoria = material.Categoria;
                existingMaterial.Descripcion = material.Descripcion;
                existingMaterial.Numero_tipo = material.Numero_tipo;
                existingMaterial.Numero_pedido = material.Numero_pedido;
                existingMaterial.PVP = material.PVP;
                existingMaterial.Descuento = material.Descuento;
                existingMaterial.Neto = material.Neto > 0 ? material.Neto : (material.PVP - (material.PVP * material.Descuento / 100));
                existingMaterial.UE = material.UE;
                existingMaterial.Neto_UE = material.Neto_UE > 0 ? material.Neto_UE : (existingMaterial.Neto * material.UE);
                existingMaterial.Fecha_precio = material.Fecha_precio;

                _context.Materiales.Update(existingMaterial);
                await _context.SaveChangesAsync();

                return existingMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el material", ex);
            }
        }

        /// <summary>
        /// Elimina un material
        /// </summary>
        public async Task<bool> DeleteMaterialAsync(int id)
        {
            try
            {
                var material = await _context.Materiales.FindAsync(id);
                if (material == null)
                {
                    return false;
                }

                _context.Materiales.Remove(material);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el material con ID {id}", ex);
            }
        }

        /// <summary>
        /// Valida que un material tenga datos válidos
        /// </summary>
        private void ValidarMaterial(Material material)
        {
            if (string.IsNullOrWhiteSpace(material.Categoria))
            {
                throw new ArgumentException("La categoría es requerida");
            }

            if (string.IsNullOrWhiteSpace(material.Descripcion))
            {
                throw new ArgumentException("La descripción es requerida");
            }

            if (material.PVP < 0)
            {
                throw new ArgumentException("El PVP no puede ser negativo");
            }

            if (material.Descuento < 0 || material.Descuento > 100)
            {
                throw new ArgumentException("El descuento debe estar entre 0 y 100");
            }

            if (material.UE <= 0)
            {
                throw new ArgumentException("La unidad de empaque debe ser mayor a 0");
            }
        }
    }
}
