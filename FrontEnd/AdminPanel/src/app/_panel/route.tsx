import { Outlet, createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/_panel')({
  component: PathlessLayoutComponent,
  // beforeLoad: ({ context, location }) => {
  //   // Replace this with your actual auth check logic
  //   const isAuthenticated = false 

  //   if (!isAuthenticated) {
  //     throw redirect({
  //       to: '/login',
  //       search: {
  //         // Keep track of where they were trying to go
  //         redirect: location.href,
  //       },
  //     })
  //   }
  // },
})

function PathlessLayoutComponent() {
  return (
    <div>
      <h1>Pathless layout</h1>
      <Outlet />
    </div>
  )
}