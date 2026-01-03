// import { useQuery } from '@tanstack/react-query';
// import api from '../../lib/api/axiosInstance';
// import { ENDPOINTS } from '../../lib/api/endpoints';
// import { QUERY_KEYS } from '../../lib/api/queryKeys';

// export const useSearchProducts = (searchTerm: string) => {
//   return useQuery({
//     // به محض تغییر searchTerm، این هوک دوباره اجرا می‌شود
//     queryKey: QUERY_KEYS.products.list({ search: searchTerm }), 
    
//     queryFn: async () => {
//       // اگر جستجو خالی بود، درخواستی نفرست (اختیاری)
//       if (!searchTerm) return []; 
      
//       const { data } = await api.get(ENDPOINTS.PRODUCT.GET_ALL, {
//         params: { q: searchTerm } // ارسال به دات‌نت
//       });
//       return data;
//     },
//     // جلوگیری از ارسال درخواست با هر بار تایپ (مهم برای پرفورمنس)
//     enabled: searchTerm.length > 2, 
//     staleTime: 60000, // کش کردن نتایج جستجو به مدت ۱ دقیقه
//   });
// };