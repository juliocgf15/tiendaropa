# StyleShop — Tienda de Ropa 👗

**Universidad de Colima · Facultad de Telemática · Programación para Web · 3a Parcial**

---

## Información del Estudiante

| Campo | Dato |
|-------|------|
| **Nombre completo** | [Tu nombre completo aquí] |
| **Número de cuenta** | [Tu número de cuenta aquí] |
| **Negocio asignado** | Tienda de Ropa |
| **Grupo** | E · 4° Semestre · Ingeniería de Software |
| **Docente** | Ing. Ricardo Jaramillo Velasco |
| **Fecha de entrega** | 29 de mayo de 2026 |

---

## API Consumida

**API asignada:** API 1 — Comercio  
**URL base:** `https://api-udec-pweb-aedec9hxbugye0am.westus3-01.azurewebsites.net`

### Endpoints consumidos

| Endpoint | Uso |
|----------|-----|
| `GET /api/comercio/productos` | Listado general del catálogo de ropa |
| `GET /api/comercio/productos/categoria/{id}` | Filtrado de productos por categoría |

---

## Tecnologías Utilizadas

- **Blazor Server** (.NET 10)
- **Entity Framework Core 10** — acceso a BD en Azure SQL
- **HttpClient con GetFromJsonAsync** — consumo de la API del profesor
- **Azure SQL Database** — base de datos en la nube
- **Git + GitHub** — control de versiones

---

## Base de Datos Propia (Azure SQL)

### Tablas

**Clientes** — Gestión de clientes (CRUD completo)
- `Id` (PK), `Nombre`, `Teléfono`, `Email`, `FechaRegistro`

**Ventas** — Registro de operaciones del negocio
- `Id` (PK), `ClienteId` (FK → Clientes), `Fecha`, `Total`, `Estado`

**DetallesVenta** — Tabla puente con la API del profesor
- `Id` (PK), `VentaId` (FK → Ventas), `ProductoApiId`, `ProductoNombre`, `Cantidad`, `Precio`

### Relaciones
- Clientes → Ventas: **Uno a muchos**
- Ventas → DetallesVenta: **Uno a muchos**
- `DetallesVenta.ProductoApiId` referencia el `Id` del producto que viene de la API (no se duplican datos maestros)

---

## Configuración de Azure SQL

Edita `appsettings.json` con tu cadena de conexión real:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:TU_SERVIDOR.database.windows.net,1433;Initial Catalog=TiendaRopaDB;User ID=TU_USUARIO;Password=TU_PASSWORD;Encrypt=True;"
  }
}
```

### Ejecutar migraciones

```bash
dotnet ef database update
```

---

## Pantallas del Sistema

### Pantalla 1 — Inicio / Dashboard
- Identidad visual de StyleShop (paleta beige/café)
- 4 indicadores: clientes registrados y ventas (BD propia) + productos y categorías disponibles (API)
- Accesos directos a los 3 módulos principales

### Pantalla 2 — Catálogo de Ropa
- Catálogo consumido desde `GET /api/comercio/productos`
- Filtro funcional por categoría usando `GET /api/comercio/productos/categoria/{id}`
- Cada producto muestra: nombre, descripción, precio, stock y disponibilidad
- Mensaje "Cargando catálogo..." mientras espera la respuesta

### Pantalla 3 — Gestión de Clientes
- **CRUD completo**: alta, consulta, edición y eliminación
- Validación de campos obligatorios (nombre, teléfono, email)
- Confirmación antes de eliminar
- Protección: no se puede eliminar un cliente con ventas registradas

### Pantalla 4 — Registro de Ventas (Integración)
- Selección de cliente de la BD propia
- Selección de productos de la API del profesor
- Al guardar, el registro se almacena con el `ProductoApiId` (sin duplicar datos maestros)
- Historial completo de ventas con detalle de productos

---

## Capturas de Pantalla

> **[Agregar aquí 4 capturas de pantalla del sistema en funcionamiento]**

---

## Cómo Ejecutar el Proyecto

```bash
# 1. Clona el repositorio
git clone https://github.com/TU_USUARIO/TiendaRopa.git
cd TiendaRopa

# 2. Configura la cadena de conexión en appsettings.json

# 3. Aplica las migraciones
dotnet ef database update

# 4. Ejecuta la aplicación
dotnet run
```

---

## Declaratoria de IA

Este proyecto fue desarrollado con apoyo de Claude (Anthropic) como herramienta de asistencia en:
- Generación de la estructura base de los componentes Blazor
- Sugerencias de diseño visual con paleta beige
- Revisión de patrones de consumo de API con `GetFromJsonAsync`

**Enlace de conversación:** [Agregar enlace de la conversación de Claude aquí]

Mi contribución personal incluye: configuración de Azure SQL, ajustes de la lógica de negocio, integración con la API del profesor, y comprensión completa de cada línea de código para la defensa oral.
