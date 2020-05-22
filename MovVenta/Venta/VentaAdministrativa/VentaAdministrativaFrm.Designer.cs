namespace MovVenta.Venta.VentaAdministrativa
{
    partial class VentaAdministrativaFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BT_BUSCAR_CLIENTE = new System.Windows.Forms.Button();
            this.L_CLIENTE = new System.Windows.Forms.Label();
            this.BT_LIMPIAR_CLIENTE = new System.Windows.Forms.Button();
            this.CB_DEPOSITO = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_SUCURSAL = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_VENDEDOR = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_COBRADOR = new System.Windows.Forms.ComboBox();
            this.L_CLIENTE_CLASIFICACION = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CB_TRANSPORTE = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.L_CLIENTE_TARIFA_PRECIO = new System.Windows.Forms.Label();
            this.CB_CONDICION_PAGO = new System.Windows.Forms.ComboBox();
            this.TB_DIAS_CREDITO = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BT_LIMPIAR = new System.Windows.Forms.Button();
            this.TB_DIR_DESPACHO = new System.Windows.Forms.TextBox();
            this.TB_NOTAS_DOC = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TB_ORDEN_COMPRA = new System.Windows.Forms.TextBox();
            this.TB_PEDIDO = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TB_DIAS_VALIDEZ = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.DTP_FECHA_PEDIDO = new System.Windows.Forms.DateTimePicker();
            this.BT_CREAR_CLIENTE = new System.Windows.Forms.Button();
            this.P_DETALLE = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.L_ITEMS = new System.Windows.Forms.Label();
            this.L_TOTAL = new System.Windows.Forms.Label();
            this.BT_ELIMINAR_ITEM = new System.Windows.Forms.Button();
            this.BT_EDITAR_ITEM = new System.Windows.Forms.Button();
            this.BT_BUSCAR_PRODUCTO = new System.Windows.Forms.Button();
            this.TB_PRODUCTO = new System.Windows.Forms.TextBox();
            this.DGV_DETALLE = new System.Windows.Forms.DataGridView();
            this.BT_TOTALIZAR = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.L_FECHA_EMISION = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.CB_SERIE = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.CB_MODO_IMPRESION = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.P_DETALLE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DETALLE)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_BUSCAR_CLIENTE
            // 
            this.BT_BUSCAR_CLIENTE.Location = new System.Drawing.Point(12, 65);
            this.BT_BUSCAR_CLIENTE.Name = "BT_BUSCAR_CLIENTE";
            this.BT_BUSCAR_CLIENTE.Size = new System.Drawing.Size(84, 23);
            this.BT_BUSCAR_CLIENTE.TabIndex = 1;
            this.BT_BUSCAR_CLIENTE.Text = "Buscar Cliente";
            this.BT_BUSCAR_CLIENTE.UseVisualStyleBackColor = true;
            this.BT_BUSCAR_CLIENTE.Click += new System.EventHandler(this.BT_BUSCAR_CLIENTE_Click);
            // 
            // L_CLIENTE
            // 
            this.L_CLIENTE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.L_CLIENTE.Location = new System.Drawing.Point(12, 91);
            this.L_CLIENTE.Name = "L_CLIENTE";
            this.L_CLIENTE.Size = new System.Drawing.Size(196, 37);
            this.L_CLIENTE.TabIndex = 1;
            // 
            // BT_LIMPIAR_CLIENTE
            // 
            this.BT_LIMPIAR_CLIENTE.Location = new System.Drawing.Point(156, 65);
            this.BT_LIMPIAR_CLIENTE.Name = "BT_LIMPIAR_CLIENTE";
            this.BT_LIMPIAR_CLIENTE.Size = new System.Drawing.Size(49, 23);
            this.BT_LIMPIAR_CLIENTE.TabIndex = 3;
            this.BT_LIMPIAR_CLIENTE.Text = "Limpiar";
            this.BT_LIMPIAR_CLIENTE.UseVisualStyleBackColor = true;
            this.BT_LIMPIAR_CLIENTE.Click += new System.EventHandler(this.BT_LIMPIAR_CLIENTE_Click);
            // 
            // CB_DEPOSITO
            // 
            this.CB_DEPOSITO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DEPOSITO.FormattingEnabled = true;
            this.CB_DEPOSITO.Location = new System.Drawing.Point(12, 305);
            this.CB_DEPOSITO.Name = "CB_DEPOSITO";
            this.CB_DEPOSITO.Size = new System.Drawing.Size(193, 21);
            this.CB_DEPOSITO.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "DEPOSITO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "SUCURSAL:";
            // 
            // CB_SUCURSAL
            // 
            this.CB_SUCURSAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_SUCURSAL.FormattingEnabled = true;
            this.CB_SUCURSAL.Location = new System.Drawing.Point(12, 259);
            this.CB_SUCURSAL.Name = "CB_SUCURSAL";
            this.CB_SUCURSAL.Size = new System.Drawing.Size(193, 21);
            this.CB_SUCURSAL.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "VENDEDOR:";
            // 
            // CB_VENDEDOR
            // 
            this.CB_VENDEDOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_VENDEDOR.FormattingEnabled = true;
            this.CB_VENDEDOR.Location = new System.Drawing.Point(12, 350);
            this.CB_VENDEDOR.Name = "CB_VENDEDOR";
            this.CB_VENDEDOR.Size = new System.Drawing.Size(193, 21);
            this.CB_VENDEDOR.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "COBRADOR:";
            // 
            // CB_COBRADOR
            // 
            this.CB_COBRADOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_COBRADOR.FormattingEnabled = true;
            this.CB_COBRADOR.Location = new System.Drawing.Point(12, 394);
            this.CB_COBRADOR.Name = "CB_COBRADOR";
            this.CB_COBRADOR.Size = new System.Drawing.Size(193, 21);
            this.CB_COBRADOR.TabIndex = 9;
            // 
            // L_CLIENTE_CLASIFICACION
            // 
            this.L_CLIENTE_CLASIFICACION.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.L_CLIENTE_CLASIFICACION.Location = new System.Drawing.Point(124, 139);
            this.L_CLIENTE_CLASIFICACION.Name = "L_CLIENTE_CLASIFICACION";
            this.L_CLIENTE_CLASIFICACION.Size = new System.Drawing.Size(84, 13);
            this.L_CLIENTE_CLASIFICACION.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "CATEGORIA:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "CONDICION PAGO:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 422);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "TRANSPORTE:";
            // 
            // CB_TRANSPORTE
            // 
            this.CB_TRANSPORTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TRANSPORTE.FormattingEnabled = true;
            this.CB_TRANSPORTE.Location = new System.Drawing.Point(12, 438);
            this.CB_TRANSPORTE.Name = "CB_TRANSPORTE";
            this.CB_TRANSPORTE.Size = new System.Drawing.Size(193, 21);
            this.CB_TRANSPORTE.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "TARIFA PRECIO:";
            // 
            // L_CLIENTE_TARIFA_PRECIO
            // 
            this.L_CLIENTE_TARIFA_PRECIO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.L_CLIENTE_TARIFA_PRECIO.Location = new System.Drawing.Point(124, 209);
            this.L_CLIENTE_TARIFA_PRECIO.Name = "L_CLIENTE_TARIFA_PRECIO";
            this.L_CLIENTE_TARIFA_PRECIO.Size = new System.Drawing.Size(84, 13);
            this.L_CLIENTE_TARIFA_PRECIO.TabIndex = 17;
            // 
            // CB_CONDICION_PAGO
            // 
            this.CB_CONDICION_PAGO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_CONDICION_PAGO.FormattingEnabled = true;
            this.CB_CONDICION_PAGO.Location = new System.Drawing.Point(124, 159);
            this.CB_CONDICION_PAGO.Name = "CB_CONDICION_PAGO";
            this.CB_CONDICION_PAGO.Size = new System.Drawing.Size(84, 21);
            this.CB_CONDICION_PAGO.TabIndex = 3;
            this.CB_CONDICION_PAGO.SelectedIndexChanged += new System.EventHandler(this.CB_CONDICION_PAGO_SelectedIndexChanged);
            // 
            // TB_DIAS_CREDITO
            // 
            this.TB_DIAS_CREDITO.Location = new System.Drawing.Point(124, 186);
            this.TB_DIAS_CREDITO.Name = "TB_DIAS_CREDITO";
            this.TB_DIAS_CREDITO.Size = new System.Drawing.Size(84, 20);
            this.TB_DIAS_CREDITO.TabIndex = 5;
            this.TB_DIAS_CREDITO.Validated += new System.EventHandler(this.TB_DIAS_CREDITO_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "DIAS/CREDITO:";
            // 
            // BT_LIMPIAR
            // 
            this.BT_LIMPIAR.Location = new System.Drawing.Point(12, 12);
            this.BT_LIMPIAR.Name = "BT_LIMPIAR";
            this.BT_LIMPIAR.Size = new System.Drawing.Size(95, 23);
            this.BT_LIMPIAR.TabIndex = 0;
            this.BT_LIMPIAR.Text = "Limpiar Ficha";
            this.BT_LIMPIAR.UseVisualStyleBackColor = true;
            this.BT_LIMPIAR.Click += new System.EventHandler(this.BT_LIMPIAR_Click);
            // 
            // TB_DIR_DESPACHO
            // 
            this.TB_DIR_DESPACHO.Location = new System.Drawing.Point(12, 482);
            this.TB_DIR_DESPACHO.Multiline = true;
            this.TB_DIR_DESPACHO.Name = "TB_DIR_DESPACHO";
            this.TB_DIR_DESPACHO.Size = new System.Drawing.Size(196, 35);
            this.TB_DIR_DESPACHO.TabIndex = 11;
            this.TB_DIR_DESPACHO.Validated += new System.EventHandler(this.TB_DIR_DESPACHO_Validated);
            // 
            // TB_NOTAS_DOC
            // 
            this.TB_NOTAS_DOC.Location = new System.Drawing.Point(12, 544);
            this.TB_NOTAS_DOC.Multiline = true;
            this.TB_NOTAS_DOC.Name = "TB_NOTAS_DOC";
            this.TB_NOTAS_DOC.Size = new System.Drawing.Size(196, 39);
            this.TB_NOTAS_DOC.TabIndex = 12;
            this.TB_NOTAS_DOC.Validated += new System.EventHandler(this.TB_NOTAS_DOC_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 466);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "DIRECCION DE DESPACHO:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 528);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "NOTAS DEL DOCUMENTO:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(225, 243);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "ORDEN COMPRA:";
            // 
            // TB_ORDEN_COMPRA
            // 
            this.TB_ORDEN_COMPRA.Location = new System.Drawing.Point(228, 260);
            this.TB_ORDEN_COMPRA.Name = "TB_ORDEN_COMPRA";
            this.TB_ORDEN_COMPRA.Size = new System.Drawing.Size(117, 20);
            this.TB_ORDEN_COMPRA.TabIndex = 13;
            this.TB_ORDEN_COMPRA.Validated += new System.EventHandler(this.TB_ORDEN_COMPRA_Validated);
            // 
            // TB_PEDIDO
            // 
            this.TB_PEDIDO.Location = new System.Drawing.Point(228, 299);
            this.TB_PEDIDO.Name = "TB_PEDIDO";
            this.TB_PEDIDO.Size = new System.Drawing.Size(117, 20);
            this.TB_PEDIDO.TabIndex = 14;
            this.TB_PEDIDO.Validated += new System.EventHandler(this.TB_PEDIDO_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(225, 283);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "PEDIDO:";
            // 
            // TB_DIAS_VALIDEZ
            // 
            this.TB_DIAS_VALIDEZ.Location = new System.Drawing.Point(228, 378);
            this.TB_DIAS_VALIDEZ.Name = "TB_DIAS_VALIDEZ";
            this.TB_DIAS_VALIDEZ.Size = new System.Drawing.Size(117, 20);
            this.TB_DIAS_VALIDEZ.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(225, 362);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "DIAS VALIDEZ:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(225, 322);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "FECHA PEDIDO:";
            // 
            // DTP_FECHA_PEDIDO
            // 
            this.DTP_FECHA_PEDIDO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_FECHA_PEDIDO.Location = new System.Drawing.Point(228, 338);
            this.DTP_FECHA_PEDIDO.Name = "DTP_FECHA_PEDIDO";
            this.DTP_FECHA_PEDIDO.Size = new System.Drawing.Size(117, 20);
            this.DTP_FECHA_PEDIDO.TabIndex = 15;
            this.DTP_FECHA_PEDIDO.Validated += new System.EventHandler(this.DTP_FECHA_PEDIDO_Validated);
            // 
            // BT_CREAR_CLIENTE
            // 
            this.BT_CREAR_CLIENTE.Location = new System.Drawing.Point(102, 65);
            this.BT_CREAR_CLIENTE.Name = "BT_CREAR_CLIENTE";
            this.BT_CREAR_CLIENTE.Size = new System.Drawing.Size(48, 23);
            this.BT_CREAR_CLIENTE.TabIndex = 2;
            this.BT_CREAR_CLIENTE.Text = "Crear";
            this.BT_CREAR_CLIENTE.UseVisualStyleBackColor = true;
            this.BT_CREAR_CLIENTE.Click += new System.EventHandler(this.BT_CREAR_CLIENTE_Click);
            // 
            // P_DETALLE
            // 
            this.P_DETALLE.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.P_DETALLE.Controls.Add(this.label17);
            this.P_DETALLE.Controls.Add(this.L_ITEMS);
            this.P_DETALLE.Controls.Add(this.L_TOTAL);
            this.P_DETALLE.Controls.Add(this.BT_ELIMINAR_ITEM);
            this.P_DETALLE.Controls.Add(this.BT_EDITAR_ITEM);
            this.P_DETALLE.Controls.Add(this.BT_BUSCAR_PRODUCTO);
            this.P_DETALLE.Controls.Add(this.TB_PRODUCTO);
            this.P_DETALLE.Controls.Add(this.DGV_DETALLE);
            this.P_DETALLE.Location = new System.Drawing.Point(373, 32);
            this.P_DETALLE.Name = "P_DETALLE";
            this.P_DETALLE.Size = new System.Drawing.Size(526, 551);
            this.P_DETALLE.TabIndex = 17;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 488);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = "Items:";
            // 
            // L_ITEMS
            // 
            this.L_ITEMS.AutoSize = true;
            this.L_ITEMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_ITEMS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.L_ITEMS.Location = new System.Drawing.Point(20, 501);
            this.L_ITEMS.Name = "L_ITEMS";
            this.L_ITEMS.Size = new System.Drawing.Size(59, 16);
            this.L_ITEMS.TabIndex = 6;
            this.L_ITEMS.Text = "label16";
            this.L_ITEMS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_TOTAL
            // 
            this.L_TOTAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TOTAL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.L_TOTAL.Location = new System.Drawing.Point(366, 496);
            this.L_TOTAL.Name = "L_TOTAL";
            this.L_TOTAL.Size = new System.Drawing.Size(140, 23);
            this.L_TOTAL.TabIndex = 5;
            this.L_TOTAL.Text = "label16";
            this.L_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BT_ELIMINAR_ITEM
            // 
            this.BT_ELIMINAR_ITEM.Location = new System.Drawing.Point(427, 33);
            this.BT_ELIMINAR_ITEM.Name = "BT_ELIMINAR_ITEM";
            this.BT_ELIMINAR_ITEM.Size = new System.Drawing.Size(79, 23);
            this.BT_ELIMINAR_ITEM.TabIndex = 3;
            this.BT_ELIMINAR_ITEM.Text = "Eliminar";
            this.BT_ELIMINAR_ITEM.UseVisualStyleBackColor = true;
            this.BT_ELIMINAR_ITEM.Click += new System.EventHandler(this.BT_ELIMINAR_ITEM_Click);
            // 
            // BT_EDITAR_ITEM
            // 
            this.BT_EDITAR_ITEM.Location = new System.Drawing.Point(427, 7);
            this.BT_EDITAR_ITEM.Name = "BT_EDITAR_ITEM";
            this.BT_EDITAR_ITEM.Size = new System.Drawing.Size(79, 23);
            this.BT_EDITAR_ITEM.TabIndex = 2;
            this.BT_EDITAR_ITEM.Text = "Editar";
            this.BT_EDITAR_ITEM.UseVisualStyleBackColor = true;
            this.BT_EDITAR_ITEM.Click += new System.EventHandler(this.BT_EDITAR_ITEM_Click);
            // 
            // BT_BUSCAR_PRODUCTO
            // 
            this.BT_BUSCAR_PRODUCTO.Location = new System.Drawing.Point(253, 36);
            this.BT_BUSCAR_PRODUCTO.Name = "BT_BUSCAR_PRODUCTO";
            this.BT_BUSCAR_PRODUCTO.Size = new System.Drawing.Size(102, 23);
            this.BT_BUSCAR_PRODUCTO.TabIndex = 1;
            this.BT_BUSCAR_PRODUCTO.Text = "Buscar Producto";
            this.BT_BUSCAR_PRODUCTO.UseVisualStyleBackColor = true;
            this.BT_BUSCAR_PRODUCTO.Click += new System.EventHandler(this.BT_BUSCAR_PRODUCTO_Click);
            // 
            // TB_PRODUCTO
            // 
            this.TB_PRODUCTO.Enabled = false;
            this.TB_PRODUCTO.Location = new System.Drawing.Point(23, 36);
            this.TB_PRODUCTO.Name = "TB_PRODUCTO";
            this.TB_PRODUCTO.Size = new System.Drawing.Size(224, 20);
            this.TB_PRODUCTO.TabIndex = 0;
            // 
            // DGV_DETALLE
            // 
            this.DGV_DETALLE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_DETALLE.Location = new System.Drawing.Point(23, 62);
            this.DGV_DETALLE.Name = "DGV_DETALLE";
            this.DGV_DETALLE.Size = new System.Drawing.Size(483, 423);
            this.DGV_DETALLE.TabIndex = 4;
            this.DGV_DETALLE.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGV_DETALLE_CellFormatting);
            this.DGV_DETALLE.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DGV_DETALLE_DataBindingComplete);
            // 
            // BT_TOTALIZAR
            // 
            this.BT_TOTALIZAR.Location = new System.Drawing.Point(976, 186);
            this.BT_TOTALIZAR.Name = "BT_TOTALIZAR";
            this.BT_TOTALIZAR.Size = new System.Drawing.Size(102, 23);
            this.BT_TOTALIZAR.TabIndex = 21;
            this.BT_TOTALIZAR.Text = "Totalizar";
            this.BT_TOTALIZAR.UseVisualStyleBackColor = true;
            this.BT_TOTALIZAR.Click += new System.EventHandler(this.BT_TOTALIZAR_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(124, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "Fecha de Emision:";
            // 
            // L_FECHA_EMISION
            // 
            this.L_FECHA_EMISION.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_FECHA_EMISION.Location = new System.Drawing.Point(121, 35);
            this.L_FECHA_EMISION.Name = "L_FECHA_EMISION";
            this.L_FECHA_EMISION.Size = new System.Drawing.Size(94, 16);
            this.L_FECHA_EMISION.TabIndex = 37;
            this.L_FECHA_EMISION.Text = "01/01/2020";
            this.L_FECHA_EMISION.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(922, 78);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 13);
            this.label18.TabIndex = 39;
            this.label18.Text = "SERIE:";
            // 
            // CB_SERIE
            // 
            this.CB_SERIE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_SERIE.FormattingEnabled = true;
            this.CB_SERIE.Location = new System.Drawing.Point(925, 94);
            this.CB_SERIE.Name = "CB_SERIE";
            this.CB_SERIE.Size = new System.Drawing.Size(153, 21);
            this.CB_SERIE.TabIndex = 19;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(922, 123);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 13);
            this.label19.TabIndex = 41;
            this.label19.Text = "MODO IMPRESION:";
            // 
            // CB_MODO_IMPRESION
            // 
            this.CB_MODO_IMPRESION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_MODO_IMPRESION.FormattingEnabled = true;
            this.CB_MODO_IMPRESION.Location = new System.Drawing.Point(925, 139);
            this.CB_MODO_IMPRESION.Name = "CB_MODO_IMPRESION";
            this.CB_MODO_IMPRESION.Size = new System.Drawing.Size(153, 21);
            this.CB_MODO_IMPRESION.TabIndex = 20;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(922, 35);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(108, 13);
            this.label20.TabIndex = 43;
            this.label20.Text = "TIPO DOCUMENTO ";
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(925, 48);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(153, 20);
            this.label21.TabIndex = 44;
            this.label21.Text = "FACTURA";
            // 
            // VentaAdministrativaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 595);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.CB_MODO_IMPRESION);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.CB_SERIE);
            this.Controls.Add(this.L_FECHA_EMISION);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.BT_TOTALIZAR);
            this.Controls.Add(this.P_DETALLE);
            this.Controls.Add(this.BT_CREAR_CLIENTE);
            this.Controls.Add(this.DTP_FECHA_PEDIDO);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.TB_DIAS_VALIDEZ);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.TB_PEDIDO);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TB_ORDEN_COMPRA);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TB_NOTAS_DOC);
            this.Controls.Add(this.TB_DIR_DESPACHO);
            this.Controls.Add(this.BT_LIMPIAR);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_DIAS_CREDITO);
            this.Controls.Add(this.CB_CONDICION_PAGO);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.L_CLIENTE_TARIFA_PRECIO);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CB_TRANSPORTE);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.L_CLIENTE_CLASIFICACION);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CB_COBRADOR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CB_VENDEDOR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CB_SUCURSAL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_DEPOSITO);
            this.Controls.Add(this.BT_LIMPIAR_CLIENTE);
            this.Controls.Add(this.L_CLIENTE);
            this.Controls.Add(this.BT_BUSCAR_CLIENTE);
            this.Name = "VentaAdministrativaFrm";
            this.Text = "VentaAdministrativaFrm";
            this.Load += new System.EventHandler(this.VentaAdministrativaFrm_Load);
            this.P_DETALLE.ResumeLayout(false);
            this.P_DETALLE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DETALLE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_BUSCAR_CLIENTE;
        private System.Windows.Forms.Label L_CLIENTE;
        private System.Windows.Forms.Button BT_LIMPIAR_CLIENTE;
        private System.Windows.Forms.ComboBox CB_DEPOSITO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_SUCURSAL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_VENDEDOR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_COBRADOR;
        private System.Windows.Forms.Label L_CLIENTE_CLASIFICACION;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CB_TRANSPORTE;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label L_CLIENTE_TARIFA_PRECIO;
        private System.Windows.Forms.ComboBox CB_CONDICION_PAGO;
        private System.Windows.Forms.TextBox TB_DIAS_CREDITO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BT_LIMPIAR;
        private System.Windows.Forms.TextBox TB_DIR_DESPACHO;
        private System.Windows.Forms.TextBox TB_NOTAS_DOC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TB_ORDEN_COMPRA;
        private System.Windows.Forms.TextBox TB_PEDIDO;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TB_DIAS_VALIDEZ;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker DTP_FECHA_PEDIDO;
        private System.Windows.Forms.Button BT_CREAR_CLIENTE;
        private System.Windows.Forms.Panel P_DETALLE;
        private System.Windows.Forms.DataGridView DGV_DETALLE;
        private System.Windows.Forms.Button BT_BUSCAR_PRODUCTO;
        private System.Windows.Forms.TextBox TB_PRODUCTO;
        private System.Windows.Forms.Button BT_ELIMINAR_ITEM;
        private System.Windows.Forms.Button BT_EDITAR_ITEM;
        private System.Windows.Forms.Label L_TOTAL;
        private System.Windows.Forms.Button BT_TOTALIZAR;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label L_ITEMS;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label L_FECHA_EMISION;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox CB_SERIE;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox CB_MODO_IMPRESION;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
    }
}