import { Dashboard } from '@/features/dashboard/components/Dashboard'
import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/_authenticated/dashboard')({
  component: Dashboard,
})


