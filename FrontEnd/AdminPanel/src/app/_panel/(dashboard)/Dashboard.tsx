import { createFileRoute } from '@tanstack/react-router'
import Example from './-components/Example'

export const Route = createFileRoute('/_panel/(dashboard)/Dashboard')({
  component: Dashboard,
})

function Dashboard() {
  return <div>Hello "/(panel)/Dashboard"!

    <Example />
  </div>
}
