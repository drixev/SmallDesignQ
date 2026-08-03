import { z } from "zod";

export const LoginRequestSchema = z.object({
  username: z
    .string()
    .min(4, "Username is required and must have at least 4 characters"),
  password: z.string().min(9, "Password must have at least 9 characters"), //FakeAdmin
});

export type LoginRequest = z.infer<typeof LoginRequestSchema>;

export const LoginResponseSchema = z.object({
  token: z.string(),
});

export type LoginResponse = z.infer<typeof LoginResponseSchema>;
