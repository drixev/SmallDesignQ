import { httpClient } from "@/lib/http-client";
import {
  LoginResponseSchema,
  type LoginRequest,
} from "../schemas/login.schema";

import { useMutation } from "@tanstack/react-query";
import { useAuthStore } from "@/stores/auth.store";
import { useNavigate } from "@tanstack/react-router";

async function loginUser(input: LoginRequest) {
  const res = await httpClient("/api/auth/login", {
    method: "POST",
    body: JSON.stringify(input),
    skipAuth: true,
  });

  return LoginResponseSchema.parse(res);
}

export const useLogin = () => {
  const setToken = useAuthStore((s) => s.setToken);
  const navigate = useNavigate();

  return useMutation({
    mutationFn: loginUser,
    onSuccess: (data) => {
      setToken(data.token);
      navigate({ to: "/dashboard" });
    },
  });
};
