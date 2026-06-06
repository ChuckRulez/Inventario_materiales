namespace InventarioMateriales.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewMateriales;
        private TextBox textBoxCategoria;
        private TextBox textBoxDescripcion;
        private TextBox textBoxNumeroTipo;
        private TextBox textBoxNumeroPedido;
        private NumericUpDown numericUpDownPVP;
        private NumericUpDown numericUpDownDescuento;
        private NumericUpDown numericUpDownNeto;
        private NumericUpDown numericUpDownUE;
        private NumericUpDown numericUpDownNetoUE;
        private DateTimePicker dateTimePickerFechaPrecio;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Button btnBuscar;
        private Button btnLimpiarBusqueda;
        private TextBox textBoxBuscarCategoria;
        private TextBox textBoxBuscarPedido;
        private Label lblCategoria;
        private Label lblDescripcion;
        private Label lblNumeroTipo;
        private Label lblNumeroPedido;
        private Label lblPVP;
        private Label lblDescuento;
        private Label lblNeto;
        private Label lblUE;
        private Label lblNetoUE;
        private Label lblFechaPrecio;
        private Label lblBuscarCategoria;
        private Label lblBuscarPedido;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Panel de búsqueda
            var panelBusqueda = new Panel();
            panelBusqueda.Dock = DockStyle.Top;
            panelBusqueda.Height = 60;
            panelBusqueda.Padding = new Padding(10);

            lblBuscarCategoria = new Label { Text = "Categoría:", Top = 10, Left = 10, Width = 80 };
            textBoxBuscarCategoria = new TextBox { Top = 10, Left = 100, Width = 200 };
            
            lblBuscarPedido = new Label { Text = "Número Pedido:", Top = 10, Left = 320, Width = 100 };
            textBoxBuscarPedido = new TextBox { Top = 10, Left = 430, Width = 200 };
            
            btnBuscar = new Button { Text = "Buscar", Top = 10, Left = 650, Width = 80, Height = 23 };
            btnBuscar.Click += btnBuscar_Click;
            
            btnLimpiarBusqueda = new Button { Text = "Limpiar", Top = 10, Left = 740, Width = 80, Height = 23 };
            btnLimpiarBusqueda.Click += btnLimpiarBusqueda_Click;

            panelBusqueda.Controls.Add(lblBuscarCategoria);
            panelBusqueda.Controls.Add(textBoxBuscarCategoria);
            panelBusqueda.Controls.Add(lblBuscarPedido);
            panelBusqueda.Controls.Add(textBoxBuscarPedido);
            panelBusqueda.Controls.Add(btnBuscar);
            panelBusqueda.Controls.Add(btnLimpiarBusqueda);

            // DataGridView
            dataGridViewMateriales = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 300,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            dataGridViewMateriales.SelectionChanged += dataGridViewMateriales_SelectionChanged;

            // Panel de formulario
            var panelFormulario = new Panel();
            panelFormulario.Dock = DockStyle.Top;
            panelFormulario.Height = 250;
            panelFormulario.Padding = new Padding(10);
            panelFormulario.AutoScroll = true;

            // Crear controles del formulario
            int y = 10;
            const int espacioVertical = 25;
            const int labelWidth = 120;
            const int controlWidth = 200;

            lblCategoria = new Label { Text = "Categoría:", Top = y, Left = 10, Width = labelWidth, AutoSize = true };
            textBoxCategoria = new TextBox { Top = y, Left = 140, Width = controlWidth };
            panelFormulario.Controls.Add(lblCategoria);
            panelFormulario.Controls.Add(textBoxCategoria);

            y += espacioVertical;
            lblDescripcion = new Label { Text = "Descripción:", Top = y, Left = 10, Width = labelWidth, AutoSize = true };
            textBoxDescripcion = new TextBox { Top = y, Left = 140, Width = controlWidth };
            panelFormulario.Controls.Add(lblDescripcion);
            panelFormulario.Controls.Add(textBoxDescripcion);

            y += espacioVertical;
            lblNumeroTipo = new Label { Text = "Número Tipo:", Top = y, Left = 10, Width = labelWidth, AutoSize = true };
            textBoxNumeroTipo = new TextBox { Top = y, Left = 140, Width = controlWidth };
            panelFormulario.Controls.Add(lblNumeroTipo);
            panelFormulario.Controls.Add(textBoxNumeroTipo);

            y += espacioVertical;
            lblNumeroPedido = new Label { Text = "Número Pedido:", Top = y, Left = 10, Width = labelWidth, AutoSize = true };
            textBoxNumeroPedido = new TextBox { Top = y, Left = 140, Width = controlWidth };
            panelFormulario.Controls.Add(lblNumeroPedido);
            panelFormulario.Controls.Add(textBoxNumeroPedido);

            y += espacioVertical;
            lblPVP = new Label { Text = "PVP:", Top = y, Left = 10, Width = labelWidth, AutoSize = true };
            numericUpDownPVP = new NumericUpDown { Top = y, Left = 140, Width = controlWidth, DecimalPlaces = 2 };
            panelFormulario.Controls.Add(lblPVP);
            panelFormulario.Controls.Add(numericUpDownPVP);

            y += espacioVertical;
            lblDescuento = new Label { Text = "Descuento %:", Top = y, Left = 10, Width = labelWidth, AutoSize = true };
            numericUpDownDescuento = new NumericUpDown { Top = y, Left = 140, Width = controlWidth, DecimalPlaces = 2, Maximum = 100 };
            panelFormulario.Controls.Add(lblDescuento);
            panelFormulario.Controls.Add(numericUpDownDescuento);

            y += espacioVertical;
            lblNeto = new Label { Text = "Neto:", Top = y, Left = 10, Width = labelWidth, AutoSize = true };
            numericUpDownNeto = new NumericUpDown { Top = y, Left = 140, Width = controlWidth, DecimalPlaces = 2 };
            panelFormulario.Controls.Add(lblNeto);
            panelFormulario.Controls.Add(numericUpDownNeto);

            // Segunda columna
            y = 10;
            lblUE = new Label { Text = "Unidad Empaque:", Top = y, Left = 360, Width = labelWidth, AutoSize = true };
            numericUpDownUE = new NumericUpDown { Top = y, Left = 490, Width = controlWidth, Minimum = 1 };
            panelFormulario.Controls.Add(lblUE);
            panelFormulario.Controls.Add(numericUpDownUE);

            y += espacioVertical;
            lblNetoUE = new Label { Text = "Neto/UE:", Top = y, Left = 360, Width = labelWidth, AutoSize = true };
            numericUpDownNetoUE = new NumericUpDown { Top = y, Left = 490, Width = controlWidth, DecimalPlaces = 2 };
            panelFormulario.Controls.Add(lblNetoUE);
            panelFormulario.Controls.Add(numericUpDownNetoUE);

            y += espacioVertical;
            lblFechaPrecio = new Label { Text = "Fecha Precio:", Top = y, Left = 360, Width = labelWidth, AutoSize = true };
            dateTimePickerFechaPrecio = new DateTimePicker { Top = y, Left = 490, Width = controlWidth };
            panelFormulario.Controls.Add(lblFechaPrecio);
            panelFormulario.Controls.Add(dateTimePickerFechaPrecio);

            // Botones de acción
            y += espacioVertical + 10;
            btnAgregar = new Button { Text = "Agregar", Top = y, Left = 140, Width = 80, Height = 30 };
            btnAgregar.Click += btnAgregar_Click;
            btnActualizar = new Button { Text = "Actualizar", Top = y, Left = 230, Width = 80, Height = 30 };
            btnActualizar.Click += btnActualizar_Click;
            btnEliminar = new Button { Text = "Eliminar", Top = y, Left = 320, Width = 80, Height = 30 };
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar = new Button { Text = "Limpiar", Top = y, Left = 410, Width = 80, Height = 30 };
            btnLimpiar.Click += btnLimpiar_Click;

            panelFormulario.Controls.Add(btnAgregar);
            panelFormulario.Controls.Add(btnActualizar);
            panelFormulario.Controls.Add(btnEliminar);
            panelFormulario.Controls.Add(btnLimpiar);

            // Agregar al formulario principal
            this.Controls.Add(panelFormulario);
            this.Controls.Add(dataGridViewMateriales);
            this.Controls.Add(panelBusqueda);

            this.Load += MainForm_Load;
        }
    }
}
