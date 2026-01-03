🛠 Naming Conventions (قوانین نام‌گذاری)
برای حفظ نظم و جلوگیری از خطا در سرور لینوکس (Debian)، رعایت قوانین زیر الزامی است:

۱. فایل‌ها (File Naming)
Hooks & Utils: تماماً kebab-case (مثلاً: use-search-products.ts)

Components: تماماً PascalCase (مثلاً: ProductCard.tsx)

Styles: تماماً kebab-case (مثلاً: main-layout.scss)

۲. توابع و متغیرها (Code Naming)
Hooks: شروع با use و به صورت camelCase (مثلاً: useDeleteProduct)

Constants: به صورت UPPER_SNAKE_CASE (مثلاً: API_BASE_URL)


📝 How to add a new API?
آدرس را در api-endpoints.ts اضافه کنید.

کلید کش را در query-keys.ts تعریف کنید.

یک هوک جدید در get-queries یا mutations با استایل kebab-case بسازید.

در کامپوننت از آن هوک استفاده کنید.

