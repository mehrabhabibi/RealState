// hooks/mutation/useDeleteProduct.ts
// import { useMutation, useQueryClient } from '@tanstack/react-query';
// import api from '../../lib/api/axiosInstance';
// import { ENDPOINTS } from '../../lib/api/endpoints';

// export const useDeleteProduct = () => {
//   const queryClient = useQueryClient();

//   return useMutation({
//     mutationFn: (id: string) => api.delete(ENDPOINTS.PRODUCT.DELETE(id)),
//     onSuccess: () => {
//       // بعد از حذف موفق، لیست محصولات را دوباره از سرور بگیر (Refetch)
//       queryClient.invalidateQueries({ queryKey: ['products'] });
//     }
//   });
// };