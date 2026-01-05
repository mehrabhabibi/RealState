🛠 Naming Conventions (قوانین نام‌گذاری)
برای حفظ نظم و جلوگیری از خطا در سرور لینوکس (Debian)، رعایت قوانین زیر الزامی است:

۱. فایل‌ها (File Naming)
Hooks & Utils: تماماً kebab-case (مثلاً: use-search-products.ts)

Components: تماماً PascalCase (مثلاً: ProductCard.tsx) // هر فایلی ک پسوند tsx داشت

Styles: تماماً kebab-case (مثلاً: main-layout.scss)

۲. توابع و متغیرها (Code Naming)
Hooks: شروع با use و به صورت camelCase (مثلاً: useDeleteProduct)

Constants: به صورت UPPER_SNAKE_CASE (مثلاً: API_BASE_URL)


📝 How to add a new API?
آدرس را در api-endpoints.ts اضافه کنید.

کلید کش را در query-keys.ts تعریف کنید.

یک هوک جدید در get-queries یا mutations با استایل kebab-case بسازید.

در کامپوننت از آن هوک استفاده کنید.


## 🛠️ Project Architecture (TanStack Router)

This project utilizes **TanStack Router's file-based routing** system. The structure is designed to colocate logic with UI while maintaining a clean URL hierarchy.

### 📂 App Folder (`src/app`)
The `app` directory serves as the routing tree:

* **`_auth/`**: A Layout Route for authentication pages. It handles the layout for Login/Register without adding `/_auth` to the URL.
* **`_panel/`**: The main protected Layout Route.
    * **`(dashboard)/`**: A route group for administrative features.
        * **`-components/`**: Private components used strictly within the dashboard.
        * **`-styles/`**: Scoped styles for the dashboard views.
* **`common/`**: Contains `layout` and `content` that are shared across the entire application (e.g., global Sidebar, Modals).

### 📡 Data Fetching & State (`src/lib`)
We use a centralized data management strategy:
* **`api/hooks/`**: Powered by **TanStack Query**. 
    * `get-queries/`: For fetching data (queries).
    * `mutation-queries/`: For data updates (POST, PUT, DELETE).
* **`store/`**: Global state management (Zustand/Signals).
* **`utils/`**: Pure helper functions and TypeScript type definitions.

### 🚀 Routing Workflow
To add a new route:
1. Create a file in `src/app/_panel/(dashboard)/new-page.tsx`.
2. The router will automatically detect it as `/new-page` under the Admin Panel layout.

src/
├── common/
│   ├──.tsx # Small UI Atoms (Buttons, Inputs)
│   ├── content/              #  UI Molucules (customer-table,header...)
│   └── layouts/              # <-- Layout Wrappers
│       ├── main-layout/      # Public Layout (Header/Footer for Landing)
│       ├── admin-layout/     # Dashboard Layout (Sidebar/Navbar)
│       └── auth-layout/      # Simple Layout for Login/Register
├── lib/
│   ├── api/                  # axios-instance, endpoints, query-keys
│   ├── hooks/                # get-queries, mutation-queries
│   ├── store/                # Zustand (e.g., useAuthStore)
│   └── utils/                # helpers.ts
├── routes/                   # Routing logic (Public vs Private routes)
└── assets/                   # Images, Icons, Global CSS