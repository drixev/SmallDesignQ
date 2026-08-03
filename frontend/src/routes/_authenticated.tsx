import { useAuthStore } from "@/stores/auth.store";
import { createFileRoute, Outlet, redirect } from "@tanstack/react-router";

export const Route = createFileRoute("/_authenticated")({
  beforeLoad: () => {
    const isAuthenticated = useAuthStore.getState().isAuthenticated;
    if (!isAuthenticated) {
      throw redirect({ to: "/login" });
    }
  },
  component: () => <Outlet />,
});
