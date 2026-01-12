# API de Vehicles i Manteniments

## Model de Dades

### **Vehicles**
- **Id**: `uniqueidentifier` (no significatiu)
- **Matrícula**: `string`
- **Model**: `string`
- **Propietari**: `uniqueidentifier`

### **Manteniments**
- **Id**: `uniqueidentifier` (no significatiu)
- **IdVehicle**: `uniqueidentifier`
- **Data**: `datetime`

### **Treballador**
- **Id**: `uniqueidentifier` (no significatiu)
- **NSS**: `string`
- **Nom**: `string`
- **Categoria**: `string`

### **Hores-Treballador**
- **Id**: `uniqueidentifier` (no significatiu)
- **IdTreballador**: `uniqueidentifier`
- **IdManteniment**: `uniqueidentifier`
- **PreuHora**: `decimal`
- **QuantitatHores**: `decimal`

---

## Funcionalitats - Vehicles

### **1. Donar d'alta un vehicle**

> **Entitat Context:** `vehicles`  
> **Entitat Acció:** `vehicles`

**Endpoint:**
```http
POST /vehicles
```

**Request Body:**
```json
{
  "matricula": "1234ABC",
  "model": "Toyota Corolla",
  "propietari": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

---

### **2. Llistar tots els manteniments d'un vehicle**

> **Entitat Context:** `vehicles`  
> **Entitat Acció:** `vehicles`

**Endpoint:**
```http
GET /vehicles/{id}/manteniments
```

---

### **3. Obtenir l'import de tots els manteniments d'un vehicle**

> **Entitat Context:** `vehicle`  
> **Entitat Acció:** `vehicle`

**Endpoint:**
```http
GET /vehicles/{id}/manteniments/import
```

**Response:**
```json
{
  "vehicleId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "importTotal": 1250.50
}
```

---

### **4. Canviar el propietari d'un vehicle**

> **Entitat Context:** `vehicle`  
> **Entitat Acció:** `vehicle`

**Endpoint:**
```http
PATCH /vehicles/{id}/propietari/{id}
```

---

## Funcionalitats - Manteniments

### **5. Crear un manteniment per al vehicle X**

> **Entitat Context:** `vehicles`  
> **Entitat Acció:** `manteniments`

**Endpoint:**
```http
POST /vehicles/{id}/manteniments
```

**Request Body:**
```json
{
  "data": "2025-11-11T10:00:00Z"
}
```

---

### **6. Obtenir l'import d'un manteniment**

> **Entitat Context:** `manteniment`  
> **Entitat Acció:** `manteniment`

**Endpoint:**
```http
GET /manteniments/{id}/import
```

**Response:**
```json
{
  "mantenimentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "import": 450.75
}
```

---

### **7. Consultar tots els treballadors assignats a un manteniment**

> **Entitat Context:** `manteniment`  
> **Entitat Acció:** `manteniment`

**Endpoint:**
```http
GET /manteniments/{id}/treballadors
```

**Response:**
```json
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nss": "281234567890",
    "nom": "Joan García",
    "categoria": "Mecànic Senior"
  }
]
```

---

## Funcionalitats - Hores

### **8. Modificar les hores d'un determinat manteniment**

> **Entitat Context:** `hores`  
> **Entitat Acció:** `hores`

**Endpoint:**
```http
PATCH /manteniments/{id}/hores
```

**Request Body:**
```json
{
  "hores": 4
}
```

---

## Funcionalitats - Treballadors

### **9. Crear un nou treballador**

> **Entitat Context:** `treballador`  
> **Entitat Acció:** `treballador`

**Endpoint:**
```http
POST /treballadors
```

**Request Body:**
```json
{
  "nss": "281234567890",
  "nom": "Maria López",
  "categoria": "Mecànic Junior"
}
```

---

### **10. Obtenir totes les hores treballades per un treballador**

> **Entitat Context:** `treballador`  
> **Entitat Acció:** `hores`

**Endpoint:**
```http
GET /treballadors/{id}/hores
```

**Response:**
```json
{
  "treballadorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "totalHores": 120.5
}
```

---

### **11. Llistar tots els manteniments en què ha participat un treballador**

> **Entitat Context:** `treballador`  
> **Entitat Acció:** `manteniments`

**Endpoint:**
```http
GET /treballadors/{id}/manteniments
```

**Response:**
```json
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "idVehicle": "7ba85f64-5717-4562-b3fc-2c963f66afa9",
    "data": "2025-11-01T10:00:00Z"
  }
]
```

---

### **12. Obtenir el cost total d'un treballador (hores × preu)**

> **Entitat Context:** `treballador`  
> **Entitat Acció:** `treballador`

**Endpoint:**
```http
GET /treballadors/{id}/cost
```

**Response:**
```json
{
  "treballadorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "costTotal": 3015.50
}
```

---

### **13. Assignar un treballador a un manteniment**

> **Entitat Context:** `treballador`  
> **Entitat Acció:** `manteniment`

**Endpoint (Opció 1):**
```http
POST /treballadors/{id}/manteniments/{id}
```

**Endpoint (Opció 2):**
```http
POST /registreHores
```

**Request Body:**
```json
{
  "idManteniment": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "idTreballador": "7ba85f64-5717-4562-b3fc-2c963f66afa9",
  "preuHora": 25.50,
  "quantitatHores": 0
}
```

---

### **14. Actualitzar dades d'un treballador**

> **Entitat Context:** `treballador`  
> **Entitat Acció:** `treballador`

**Endpoint:**
```http
PATCH /treballadors/{id}
```

**Request Body:**
```json
{
  "nom": "Maria López García",
  "categoria": "Mecànic Senior"
}
```

---

### **15. Incrementar el preu hora associat a un treballador**

> **Entitat Context:** `registreHores`  
> **Entitat Acció:** `registreHores`

**Endpoint:**
```http
PATCH /registreHores/{id}
```

**Request Body:**
```json
{
  "IncrementPreu": 28.75
}
```

---

## Notes d'Implementació

- Tots els IDs són de tipus `uniqueidentifier` (GUID)
- Els imports es calculen com: **QuantitatHores × PreuHora**
- Les dates segueixen el format ISO 8601
- Els endpoints PATCH permeten actualitzacions parcials
- Els endpoints GET retornen 404 si el recurs no existeix

---

## Consideracions de Seguretat

- Validar totes les entrades d'usuari
- Implementar autenticació i autorització
- Registrar totes les operacions de modificació
- Utilitzar transaccions per a operacions crítiques