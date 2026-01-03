export const ENDPOINTS = {
  PRODUCT: {
    GET_ALL: '/products',
    GET_ONE: (id: string) => `/products/${id}`,
    DELETE: (id: string) => `/products/admin/delete/${id}`,
  },
  USER: {
    PROFILE: '/user/profile',
    UPDATE: '/user/update-info',
  }
};