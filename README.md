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

## 📁 Arquitectura

Este sistema sigue una arquitectura en 4 capas:

- `BE` (Business Entities): Clases y entidades del dominio.
- `BLL` (Business Logic Layer): Lógica de negocio y validaciones.
- `DAL` (Data Access Layer): Acceso y manipulación de datos (SQL Server).
- `GUI` (Graphical User Interface): Interfaz de usuario con formularios MDI.

---


## 🏗️ Patrones de Diseño Utilizados

### Singleton

**¿Qué problemática resuelve?**  
Evita la creación de múltiples instancias de una clase que debe tener una única instancia global en la aplicación, como el manejo de sesión de usuario o la gestión de traducciones.

**¿Cómo se resolvió en la solución?**  
Se implementa en clases como `LoginSession` y `Traductor`, donde la propiedad estática `Instancia` asegura que solo exista un objeto accesible globalmente. El constructor es privado y la instancia se crea bajo demanda.

**Consecuencias buenas:**  
- Garantiza un único punto de acceso y control de estado global (ej: usuario logueado, idioma actual).
- Facilita la gestión de recursos compartidos.


---

### Composite

**¿Qué problemática resuelve?**  
Permite tratar objetos individuales y composiciones de objetos de manera uniforme. Es útil para representar jerarquías como permisos y perfiles, donde un permiso puede ser simple (Patente) o compuesto (Familia).

**¿Cómo se resolvió en la solución?**  
Se implementa en la jerarquía de clases `Componente`, `Patente` y `Familia`. `Familia` puede contener hijos de tipo `Componente`, permitiendo construir árboles de permisos. El sistema de gestión de perfiles y asignación de permisos utiliza este patrón para mostrar y manipular la jerarquía.

**Consecuencias buenas:**  
- Permite construir estructuras jerárquicas flexibles y escalables.
- Facilita operaciones recursivas (ej: validación, visualización en árbol).

**Limitaciones:**  
- Puede agregar complejidad si la jerarquía es muy profunda o si se requieren operaciones específicas para tipos concretos.

---

### Observer

**¿Qué problemática resuelve?**  
Permite que varios objetos (observadores) sean notificados automáticamente cuando el estado de otro objeto (sujeto) cambia. Es útil para actualizar la interfaz de usuario cuando cambia el idioma.

**¿Cómo se resolvió en la solución?**  
Se implementa en la clase `Traductor`, que mantiene una lista de observadores (`IIdiomaObserver`). Los formularios se suscriben y, al cambiar el idioma, el traductor notifica a todos los observadores para que actualicen sus textos.

**Consecuencias buenas:**  
- Desacopla el origen del cambio (idioma) de los componentes que deben reaccionar.
- Facilita la extensión: nuevos formularios solo deben suscribirse.

**Limitaciones:**  
- Si hay muchos observadores, puede haber un pequeño impacto en el rendimiento.

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
- .NET 8.0+
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

## 📬 Contacto

Desarrollado por **Ifrene Arlando A**  
Para consultas o soporte: _[arlandoifrene@gmail.com]_
