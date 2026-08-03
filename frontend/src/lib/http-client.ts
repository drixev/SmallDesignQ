import { getAuthToken } from "@/stores/auth.store";

const BASE_URL = import.meta.env.VITE_API_URL;

interface RequestOptions extends RequestInit {
  skipAuth?: boolean;
}

export const httpClient = async (
  path: string,
  options: RequestOptions = {},
) => {
  const { skipAuth, headers, ...rest } = options;

  const token = getAuthToken();

  const res = await fetch(`${BASE_URL}${path}`, {
    ...rest,
    headers: {
      "Content-Type": "application/json",
      ...(!skipAuth && token
        ? {
            Authorization: `Bearer ${token}`,
          }
        : {}),
      ...headers,
    },
  });

  if (res.status === 401) {
    throw new Error("Your session ended");
  }

  if (!res.ok) {
    throw new Error(`Error ${res.status}: ${res.statusText}`);
  }

  return res.json();
};
