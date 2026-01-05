import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/_panel/')({
  component: Panel,
})

function Panel() {
  return <div>Hello "/(panel)/Panel"!</div>
}
