import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import './index.css'
import { Auth0Provider } from '@auth0/auth0-react';
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import UserProfile from './pages/UserProfile.jsx';
import Lab1 from './pages/Lab1.jsx';
import Lab2 from './pages/Lab2.jsx';
import Lab3 from './pages/Lab3.jsx';

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
  },
  {
    path: "/profile",
    element: <UserProfile />,
  },
  {
    path: "/lab1",
    element: <Lab1 />
  },
  {
    path: "/lab2",
    element: <Lab2 />
  },
  {
    path: "/lab3",
    element: <Lab3 />
  },
]);

ReactDOM.createRoot(document.getElementById('root')).render(
<Auth0Provider
    domain="dev-scsneb7gbc2lrzrb.us.auth0.com"
    clientId="iszkIPtXsb9JHBytoXFtYpWzE1wwNEvM"
    authorizationParams={{
      redirect_uri: "http://localhost:5173/"
    }}
  >
    <RouterProvider router={router} />
  </Auth0Provider>,
)
