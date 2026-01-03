export const QUERY_KEYS = {
  products: {
    all: ['products'] as const,
    // دریافت فیلترها به عنوان ورودی برای ساخت کلید یکتا
    list: (params: object) => [...QUERY_KEYS.products.all, 'list', params] as const,
  }
};