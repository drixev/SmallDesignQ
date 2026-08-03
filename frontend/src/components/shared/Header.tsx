import { useAuthStore } from "@/stores/auth.store";
import { Button } from "@/components/ui/button";
import { useNavigate } from "@tanstack/react-router";

export const Header = () => {
  const { logout } = useAuthStore();
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate({ to: "/login" });
  };

  return (
    <header className="flex items-center justify-between">
      <h1 className="text-lg font-semibold">Dashboard</h1>
      <Button variant="outline" size="sm" onClick={handleLogout}>
        Logout
      </Button>
    </header>
  );
};
