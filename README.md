# 📄 Docable – Turn Data into Documents Seamlessly

**Docable** is a powerful, minimal API service that transforms your structured JSON data into beautifully styled PDF documents using predefined templates. It's perfect for generating invoices, letters, and more — all through a simple POST request.

---
## ✨ Live Preview : https://docable.vercel.app/

- Input JSON in editor
- Select template (Invoice / Letter)
- Get instant PDF preview

  
## 🚀 Features

- ⚡ Convert JSON to PDF instantly
- 🧾 Built-in templates: Invoice, Letter
- 🌐 REST API – easy to integrate
- 🖥️ Live frontend for testing and preview
- 🎨 Built with QuestPDF and React (Tailwind)

---

## 📦 Tech Stack

| Layer     | Technology              |
|-----------|--------------------------|
| Backend   | ASP.NET Core Web API     |
| PDF Engine| QuestPDF                 |
| Frontend  | React + Tailwind CSS     |
| Templating| Scriban (for structure)  |

---

## 📬 API Usage

### Base URL

```
https://docable.azurewebsites.net/api/pdf/generate/{template}
```

### Supported Templates

- `invoice`
- `letter`

### Example Request (invoice)

**POST** `/api/pdf/generate/invoice`  
Content-Type: `application/json`

```json
{
  "companyName": "string",
  "invoiceNumber": "string",
  "...": "..."
}
```

### Response

- Content-Type: `application/pdf`
- Returns: PDF blob

Example (JavaScript):

```js
const blob = await response.blob();
const url = URL.createObjectURL(blob);
window.open(url);
```

---

## 🖥️ Running Locally

### Backend (.NET API)

```bash
dotnet restore
dotnet run
```
---

## 📖 Templates

### 1. Invoice Template JSON

```json
{
  "companyName": "string",
  "companyStreet": "string",
  "companyCityZip": "string",
  "companyPhone": "string",
  "companyFax": "string",
  "companyWebsite": "string",
  "invoiceDate": "string",
  "invoiceNumber": "string",
  "customerId": "string",
  "dueDate": "string",
  "clientName": "string",
  "clientCompany": "string",
  "clientStreet": "string",
  "clientCityZip": "string",
  "clientPhone": "string",
  "items": [
    {
      "description": "string",
      "isTaxed": true,
      "amount": 0
    }
  ],
  "subtotal": 0,
  "taxableAmount": 0,
  "taxRate": 0,
  "taxDue": 0,
  "otherCharges": 0,
  "total": 0,
  "otherComments": [
    "string"
  ],
  "contactInfo": "string"
}
```

### 2. Letter Template JSON

```json
{
  "senderName": "string",
  "senderTitle": "string",
  "senderCompany": "string",
  "senderAddress": "string",
  "recipientName": "string",
  "recipientTitle": "string",
  "recipientCompany": "string",
  "recipientAddress": "string",
  "date": "string",
  "subject": "string",
  "body": "string",
  "closing": "string",
  "signatureName": "string",
  "signatureTitle": "string"
}
```


## 📝 License

MIT © 2025 Mutashim / Docable
