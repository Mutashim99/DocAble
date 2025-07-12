# 📄 Project Summary – PDF Report Generator with AI (Pdfy)

## 🎯 Project Goal:
Build a full-stack PDF Report Generator that accepts structured JSON input and returns a styled, downloadable PDF using dynamic templates. The system also uses AI (Groq + Mixtral) to intelligently enhance or complete missing data when necessary, making it smart and user-friendly.

---

## 🧠 Core Functionalities

- ✅ Accept JSON input (via API or form)
- ✅ Map data to Scriban template (e.g., letter, invoice, summary)
- ✅ Render HTML → PDF using DinkToPdf
- ✅ Return the final PDF to the user
- ✅ Use **Groq + Mixtral AI API** to auto-generate missing or enhanced content
- ✅ Supports multiple real-world use cases:
  - Letter generator (resignation, visa, job offer)
  - Invoice/report builder
  - Summary PDF from raw inputs (future)

---

## 🧪 Tech Stack

### Backend
- ASP.NET Core Web API
- Scriban (template engine)
- DinkToPdf (HTML to PDF)
- HttpClient (AI calls)
- Optional: Docker, GitHub Actions, Render or Azure for deployment

### AI Integration
- **Groq API** (using Mixtral model)
- Use cases:
  - Generate letter content from short prompts
  - Fill missing fields in JSON
  - Polish or rephrase input

### Frontend (Planned)
- React or Next.js
- TailwindCSS
- Simple UI to fill form, preview, and download PDF

---

## 🧱 Architecture Flow

## JSON Input → Validate/Parse → [AI Fallback if needed] → Scriban Template → HTML → DinkToPdf → PDF Output


---

## 🛠 Key Features To Build

- `POST /generate-letter` endpoint
- Letter, invoice, summary templates (customizable)
- AI integration only when user input is incomplete or basic
- Optional features:
  - API Key auth for SaaS model
  - Rate limiting per user
  - Frontend: Template preview & regenerate with AI

---

## 💡 Vision

> A lightweight, developer-friendly API and micro-SaaS tool that generates polished business documents from JSON input — enhanced by AI when needed.

