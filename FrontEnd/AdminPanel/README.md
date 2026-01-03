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

src/
├── app/
│   ├── auth/                 # Login/Register Pages
│   ├── dashboard/            # Admin/User Panel Dashboead Page route
│   │   ├── components/
│   │   └── styles/
│   └── landing/              Panel
│       ├── components/       Panel
│       └── styles/.less
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