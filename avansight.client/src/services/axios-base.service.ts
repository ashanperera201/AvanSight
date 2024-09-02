import axios from 'axios';

export const baseUrl = import.meta.env.VITE_API_BASE_URL;

const axiosBase = axios.create({
  baseURL: `${baseUrl}`,
  timeout: 10000,
});

export default axiosBase;
