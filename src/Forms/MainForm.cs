using InventarioMateriales.Models;
using InventarioMateriales.Services;

namespace InventarioMateriales.Forms
{
    public partial class MainForm : Form
    {
        private readonly MaterialService _materialService;
        private Material? _materialActual;

        public MainForm(MaterialService materialService)
        {
            InitializeComponent();
            _materialService = materialService;
            this.Text = "Inventario de Materiales";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                await CargarMateriales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los materiales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarMateriales()
        {
            try
            {
                var materiales = await _materialService.GetAllMaterialesAsync();
                ActualizarDataGrid(materiales);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los materiales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarDataGrid(List<Material> materiales)
        {
            dataGridViewMateriales.DataSource = null;
            dataGridViewMateriales.DataSource = materiales;

            // Ajustar ancho de columnas
            if (dataGridViewMateriales.Columns.Count > 0)
            {
                dataGridViewMateriales.Columns["ID"].Width = 50;
                dataGridViewMateriales.Columns["Categoria"].Width = 100;
                dataGridViewMateriales.Columns["Descripcion"].Width = 150;
                dataGridViewMateriales.Columns["Numero_tipo"].Width = 80;
                dataGridViewMateriales.Columns["Numero_pedido"].Width = 100;
                dataGridViewMateriales.Columns["PVP"].Width = 80;
                dataGridViewMateriales.Columns["Descuento"].Width = 80;
                dataGridViewMateriales.Columns["Neto"].Width = 80;
                dataGridViewMateriales.Columns["Neto_UE"].Width = 90;
            }
        }

        private void dataGridViewMateriales_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMateriales.SelectedRows.Count > 0)
            {
                var row = dataGridViewMateriales.SelectedRows[0];
                CargarDatosEnFormulario(row);
            }
        }

        private void CargarDatosEnFormulario(DataGridViewRow row)
        {
            try
            {
                _materialActual = new Material
                {
                    ID = (int)row.Cells["ID"].Value,
                    Categoria = row.Cells["Categoria"].Value?.ToString() ?? "",
                    Descripcion = row.Cells["Descripcion"].Value?.ToString() ?? "",
                    Numero_tipo = row.Cells["Numero_tipo"].Value?.ToString(),
                    Numero_pedido = row.Cells["Numero_pedido"].Value?.ToString(),
                    PVP = Convert.ToDecimal(row.Cells["PVP"].Value),
                    Descuento = Convert.ToDecimal(row.Cells["Descuento"].Value),
                    Neto = Convert.ToDecimal(row.Cells["Neto"].Value),
                    UE = (int)row.Cells["UE"].Value,
                    Neto_UE = Convert.ToDecimal(row.Cells["Neto_UE"].Value),
                    Fecha_precio = Convert.ToDateTime(row.Cells["Fecha_precio"].Value)
                };

                MostrarDatosEnFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosEnFormulario()
        {
            if (_materialActual != null)
            {
                textBoxCategoria.Text = _materialActual.Categoria;
                textBoxDescripcion.Text = _materialActual.Descripcion;
                textBoxNumeroTipo.Text = _materialActual.Numero_tipo ?? "";
                textBoxNumeroPedido.Text = _materialActual.Numero_pedido ?? "";
                numericUpDownPVP.Value = _materialActual.PVP;
                numericUpDownDescuento.Value = _materialActual.Descuento;
                numericUpDownNeto.Value = _materialActual.Neto;
                numericUpDownUE.Value = _materialActual.UE;
                numericUpDownNetoUE.Value = _materialActual.Neto_UE;
                dateTimePickerFechaPrecio.Value = _materialActual.Fecha_precio;
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();

                var material = new Material
                {
                    Categoria = textBoxCategoria.Text,
                    Descripcion = textBoxDescripcion.Text,
                    Numero_tipo = textBoxNumeroTipo.Text,
                    Numero_pedido = textBoxNumeroPedido.Text,
                    PVP = numericUpDownPVP.Value,
                    Descuento = numericUpDownDescuento.Value,
                    Neto = numericUpDownNeto.Value,
                    UE = (int)numericUpDownUE.Value,
                    Neto_UE = numericUpDownNetoUE.Value,
                    Fecha_precio = dateTimePickerFechaPrecio.Value
                };

                await _materialService.CreateMaterialAsync(material);
                MessageBox.Show("Material agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                await CargarMateriales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar material: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_materialActual == null)
                {
                    MessageBox.Show("Seleccione un material para actualizar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ValidarCampos();

                _materialActual.Categoria = textBoxCategoria.Text;
                _materialActual.Descripcion = textBoxDescripcion.Text;
                _materialActual.Numero_tipo = textBoxNumeroTipo.Text;
                _materialActual.Numero_pedido = textBoxNumeroPedido.Text;
                _materialActual.PVP = numericUpDownPVP.Value;
                _materialActual.Descuento = numericUpDownDescuento.Value;
                _materialActual.Neto = numericUpDownNeto.Value;
                _materialActual.UE = (int)numericUpDownUE.Value;
                _materialActual.Neto_UE = numericUpDownNetoUE.Value;
                _materialActual.Fecha_precio = dateTimePickerFechaPrecio.Value;

                await _materialService.UpdateMaterialAsync(_materialActual);
                MessageBox.Show("Material actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                await CargarMateriales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar material: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_materialActual == null)
                {
                    MessageBox.Show("Seleccione un material para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resultado = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar '{_materialActual.Descripcion}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    await _materialService.DeleteMaterialAsync(_materialActual.ID);
                    MessageBox.Show("Material eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    await CargarMateriales();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar material: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var categoria = textBoxBuscarCategoria.Text;
                var numeroPedido = textBoxBuscarPedido.Text;

                var materiales = await _materialService.BuscarMaterialesAsync(categoria, numeroPedido);
                ActualizarDataGrid(materiales);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            textBoxBuscarCategoria.Clear();
            textBoxBuscarPedido.Clear();
            await CargarMateriales();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            textBoxCategoria.Clear();
            textBoxDescripcion.Clear();
            textBoxNumeroTipo.Clear();
            textBoxNumeroPedido.Clear();
            numericUpDownPVP.Value = 0;
            numericUpDownDescuento.Value = 0;
            numericUpDownNeto.Value = 0;
            numericUpDownUE.Value = 1;
            numericUpDownNetoUE.Value = 0;
            dateTimePickerFechaPrecio.Value = DateTime.Now;
            _materialActual = null;
        }

        private void ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textBoxCategoria.Text))
                throw new Exception("La categoría es requerida");

            if (string.IsNullOrWhiteSpace(textBoxDescripcion.Text))
                throw new Exception("La descripción es requerida");

            if (numericUpDownPVP.Value < 0)
                throw new Exception("El PVP no puede ser negativo");

            if (numericUpDownUE.Value <= 0)
                throw new Exception("La unidad de empaque debe ser mayor a 0");
        }
    }
}
