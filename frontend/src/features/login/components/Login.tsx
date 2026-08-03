import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { Form } from "@base-ui/react/form";
import { useLogin } from "../api/use-login";
import { LoginRequestSchema, type LoginRequest } from "../schemas/login.schema";
import { Input } from "@base-ui/react/input";
import { Button } from "@/components/ui/button";

export const Login = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<LoginRequest>({
    resolver: zodResolver(LoginRequestSchema),
  });

  const { mutate: loginFn, error, isPending } = useLogin();

  return (
    <div className="flex min-h-svh items-center justify-center bg-muted/30 p-4">
      <div className="w-full max-w-sm rounded-xl border border-border bg-background p-6 shadow-sm">
        <div className="mb-6 space-y-1 text-center">
          <h1 className="text-xl font-semibold">Welcome back</h1>
          <p className="text-sm text-muted-foreground">
            Sign in to your account to continue
          </p>
        </div>

        <Form
          onSubmit={handleSubmit((data) => loginFn(data))}
          className="space-y-4"
        >
          <Input placeholder="Username" {...register("username")} />
          {errors.username && (
            <p className="text-sm text-red-500">{errors.username.message}</p>
          )}

          <Input placeholder="Password" {...register("password")} />
          {errors.password && (
            <p className="text-sm text-red-500">{errors.password.message}</p>
          )}

          {error && <p className="text-sm text-red-500">Username or password are incorrect</p>}

          <Button type="submit" disabled={isPending} className="w-full">
            {isPending ? "Wait a minute..." : "Login"}
          </Button>
        </Form>
      </div>
    </div>
  );
};
