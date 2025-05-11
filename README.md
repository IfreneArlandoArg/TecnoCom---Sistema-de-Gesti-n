# 🖥️ TecnoCom - Sistema de Gestión y Ventas

Sistema de gestión y ventas para **TecnoCom**, un comercio especializado en hardware informático. Esta aplicación de escritorio permite informatizar procesos clave del negocio como ventas, compras, control de stock, facturación y generación de reportes estratégicos, utilizando una arquitectura de 4 capas: **BE, BLL, DAL y GUI**.

---

## 📌 Propósito

El sistema surge como respuesta a la necesidad de modernizar los procesos de gestión del comercio, actualmente manuales o dispersos. Se busca:

- Centralizar operaciones claves.
- Reducir errores e ineficiencias.
- Mejorar el control y visibilidad del stock.
- Apoyar la toma de decisiones mediante reportes estratégicos.

---

## ⚙️ Funcionalidades Principales

### 📦 Gestiones organizacionales:
- **Ventas de hardware**: consulta de stock, selección de productos, registro del cliente, facturación y entrega.
- **Gestión de clientes**: alta y mantenimiento.
- **Compras a proveedores**: cotizaciones, órdenes, pagos y recepción.
- **Control de stock**: actualización automática, alertas por stock crítico.
- **Reportes administrativos**: mensuales y estratégicos.

### ⭐ Características destacadas:
- Facturación manual con POSNET externo.
- Reportes de productos más vendidos, márgenes operativos y desempeño por proveedor.

---

## 🔒 Alcance del Sistema

### ✔️ Incluye:
- Venta presencial.
- Gestión de clientes, productos y proveedores.
- Facturación manual.
- Control de stock.
- Generación de órdenes de compra.
- Reportes administrativos.

### ❌ No incluye:
- E-commerce.
- Integración contable externa.
- Soporte técnico o garantía postventa.
- Logística o envíos a domicilio.

---

## 🧠 Definiciones y Términos

| Término | Definición |
|--------|------------|
| **CLIENTE** | Persona física o jurídica que realiza compras |
| **PRODUCTO DE HARDWARE** | Componente físico (RAM, disco, etc.) vendido por el comercio |
| **PROVEEDOR** | Entidad que provee productos a TecnoCom |
| **FACTURA** | Documento generado para registrar una venta |

### Acrónimos:
- **POSNET**: Terminal externa para cobro con tarjeta.

### Abreviaturas:
- **ARG**: Argentina
- **ID**: Identificador único

---

## 👥 Roles y Participantes

### Participantes del Proyecto:

| Nombre           | Descripción                         | Responsabilidad                         |
|------------------|-------------------------------------|------------------------------------------|
| Juan Garcia      | Gerente de Producción               | Define procesos y necesidades funcionales |
| María Martinez   | Analista Funcional Producción/Ventas| Documentación de requerimientos y casos de uso |
| Ifrene Arlando   | Desarrollador del sistema           | Implementación y validación técnica      |

### Usuarios y Roles:

| Usuario   | Rol           | Acceso                                                              |
|-----------|---------------|---------------------------------------------------------------------|
| Juan Garcia | Producción   | Órdenes de compra, stock, costos de producción, estadísticas        |
| Vendedor    | Ventas       | Consulta de stock, registro de ventas, emisión de facturas          |
| Compras     | Comprador    | Cotizaciones, órdenes de compra, pagos a proveedores                |
| Admin       | Administrador| Acceso total a módulos y reportes estratégicos                      |

---

## 🛠 Requisitos Técnicos

### 🔧 Del Producto:
- Interfaz amigable y validación de datos.
- Almacenamiento seguro de información.

### 💻 Requisitos del Sistema:
- Windows 10 o superior.
- .NET 6.0+
- SQL Server 2022

### 🌐 Entorno de Desarrollo:
- Lenguaje: **C# .NET Core 6.0+**
- Base de datos: **SQL Server**
- Infraestructura: Aplicación de escritorio o cliente en red local

---

## 📄 Documentación

- Manual de usuario con capturas de pantalla.
- Guía de instalación y configuración.
- Archivo `README` detallando entorno de desarrollo y despliegue.

---

## 📁 Arquitectura

Este sistema sigue una arquitectura en 4 capas:

- `BE` (Business Entities): Clases y entidades del dominio.
- `BLL` (Business Logic Layer): Lógica de negocio y validaciones.
- `DAL` (Data Access Layer): Acceso y manipulación de datos (SQL Server).
- `GUI` (Graphical User Interface): Interfaz de usuario con formularios MDI.

---

## 📬 Contacto

Desarrollado por **Ifrene Arlando**  
Para consultas o soporte: _[arlandoifrene@gmail.com]_
