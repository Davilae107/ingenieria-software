# 🏗️ Estructura de Ramas y Workflow CI/CD

## 📋 Descripción del Proyecto

Proyecto **TDD - Máquina Dispensadora de Café** en C# con NUnit, implementado siguiendo la metodología de **Test-Driven Development**.

---

## 🌳 Estructura de Ramas

```
main (producción)
├── develop (integración)
│   └── feature/nueva-funcionalidad (características nuevas)
```

### **main** 🔴
- **Propósito**: Rama de producción
- **Quién actualiza**: Solo mediante Pull Requests desde `develop`
- **Requisitos**: Todas las pruebas deben pasar
- **Protegida**: Sí (requiere revisión antes de merge)

### **develop** 🟡
- **Propósito**: Rama de integración para desarrollo
- **Quién actualiza**: Merge de features completadas
- **Requisitos**: Todas las pruebas deben pasar
- **Estado**: Siempre lista para hacer PR a `main`

### **feature/nueva-funcionalidad** 🟢
- **Propósito**: Desarrollar nuevas características
- **Quién actualiza**: Desarrolladores que trabajan en features específicas
- **Creación**: `git checkout -b feature/nombre-de-feature develop`
- **Merge**: PR hacia `develop` cuando está lista

---

## 🔄 Flujo de Trabajo (Git Flow)

### 1️⃣ Crear una nueva característica

```bash
# Actualizar develop
git checkout develop
git pull origin develop

# Crear rama de feature
git checkout -b feature/mi-nueva-funcionalidad

# Hacer cambios...
git add .
git commit -m "feat: Descripción de la característica"
git push origin feature/mi-nueva-funcionalidad
```

### 2️⃣ Crear un Pull Request

En GitHub:
1. Ir a la rama en GitHub
2. Hacer clic en "Compare & pull request"
3. Cambiar base a `develop`
4. Escribir descripción clara
5. Solicitar revisión

### 3️⃣ Después de la aprobación

```bash
# Merge en develop (desde GitHub UI o CLI)
git checkout develop
git pull origin develop
git merge feature/mi-nueva-funcionalidad
git push origin develop
```

### 4️⃣ Liberar a producción

Cuando `develop` está estable:
```bash
git checkout main
git pull origin main
git merge develop
git tag -a v1.0.0 -m "Version 1.0.0"
git push origin main --tags
```

---

## 🤖 CI/CD Pipeline (GitHub Actions)

### **Archivo**: `.github/workflows/ci-pipeline.yml`

El pipeline se ejecuta automáticamente en:
- ✅ `push` a cualquier rama (`main`, `develop`, `feature/*`)
- ✅ `pull_request` hacia `main` o `develop`

### **Pasos del Pipeline**

1. **Clonar repositorio**
   - Obtiene el código de la rama

2. **Configurar entorno**
   - Prepara el ambiente de compilación

3. **Instalar .NET 9.0**
   - Descarga el runtime necesario

4. **Restaurar dependencias**
   - `dotnet restore`

5. **Compilar proyecto**
   - `dotnet build --configuration Release`

6. **Ejecutar pruebas unitarias**
   - `dotnet test --configuration Release`

### **Estado del Pipeline**

- 🟢 **PASS**: Todos los pasos completados correctamente
- 🔴 **FAIL**: Algún paso falló (generalmente compilación o pruebas)

---

## 📁 Estructura del Proyecto

```
ingenieria-software/
├── .github/
│   └── workflows/
│       └── ci-pipeline.yml          # ⚙️ Configuración CI/CD
├── Cafetera.Domain/
│   ├── Vaso.cs                      # Clase de vasos
│   ├── Cafetera.cs                  # Clase de café
│   ├── Azucarero.cs                 # Clase de azúcar
│   ├── MaquinaDeCafe.cs             # Clase principal
│   └── Cafetera.Domain.csproj
├── Cafetera.Tests/
│   ├── TestVaso.cs                  # Pruebas de Vaso
│   ├── TestCafetera.cs              # Pruebas de Cafetera
│   ├── TestAzucarero.cs             # Pruebas de Azucarero
│   ├── TestMaquinaDeCafe.cs         # Pruebas de MaquinaDeCafe
│   └── Cafetera.Tests.csproj
├── CafeteraTDD.sln                  # Solución .NET
├── README.md                         # Este archivo
└── .gitignore                        # Archivos a ignorar

```

---

## 🚀 Comandos Útiles

### Verificar estado

```bash
# Ver ramas locales
git branch

# Ver ramas remotas
git branch -a

# Ver historial de commits
git log --oneline --graph --all

# Ver cambios no comprometidos
git status
```

### Trabajar con cambios

```bash
# Ver cambios específicos
git diff

# Agregar archivos
git add .
git add archivo.cs

# Hacer commit
git commit -m "feat: Mi cambio"
git commit -m "fix: Corregir bug"
git commit -m "docs: Actualizar documentación"

# Actualizar rama
git pull origin develop

# Enviar cambios
git push origin feature/mi-funcionalidad
```

### Sincronizar con develop

```bash
# Si tu rama feature está atrasada
git fetch origin
git rebase origin/develop

# O hacer merge (menos limpio)
git merge origin/develop
```

---

## ✅ Checklist Antes de PR

- [ ] Todas las pruebas pasan: `dotnet test`
- [ ] El código compila sin warnings: `dotnet build`
- [ ] Agregaste pruebas para la nueva funcionalidad
- [ ] Seguiste el patrón TDD (Red → Green → Refactor)
- [ ] Documentaste cambios significativos
- [ ] Commits con mensajes claros (feat:, fix:, docs:)
- [ ] La rama está actualizada con develop: `git rebase origin/develop`

---

## 📝 Convención de Commits

```
feat: Nueva característica
fix: Corrección de bug
docs: Cambios en documentación
refactor: Refactorización de código
test: Agregar o modificar pruebas
chore: Cambios de configuración o dependencias
```

**Ejemplo**:
```bash
git commit -m "feat: Agregar método para validar disponibilidad de vasos"
git commit -m "fix: Corregir cálculo de café necesario"
git commit -m "test: Agregar prueba para MaquinaDeCafe"
```

---

## 🔍 Monitoreo del Pipeline

1. Ir a GitHub: https://github.com/Davilae107/ingenieria-software
2. Click en la pestaña **"Actions"**
3. Ver el estado de los workflow
4. Hacer clic en un workflow para ver detalles

---

## 📞 Soporte

Si el pipeline falla:

1. ✅ Verifica que pasan las pruebas localmente: `dotnet test`
2. ✅ Verifica que compila: `dotnet build`
3. ✅ Revisa los logs del workflow en GitHub Actions
4. ✅ Consulta los cambios no comprometidos: `git status`

---

**Última actualización**: Noviembre 2025
**Versión**: 1.0.0
