import Home from "../pages/site/Home/Home"
import Blog from "../pages/site/Blog/Blog"
import Contact from "../pages/site/Contact/Contact"
import Moves from "../pages/site/Moves/Moves"
import Shop from "../pages/site/Shop/Shop"
import AdminRoot from "../pages/admin/adminRoute/AdminRoot";
import Dashboard from "../pages/admin/dashboard/Dashboard";
import SiteRoot from "../pages/site/siteRoute/SiteRoot"
import Error from "../pages/error/Error"
import ProductDetail from "../pages/site/Shop/ProductDetail"
export const ROUTES = [{
    path: "/",
    element: <SiteRoot />,
    children: [
        {
            path: "",
            element: <Home />
        },
        {
            path: "blog",
            element: <Blog />
        },
        {
            path: "contact",
            element: <Contact />
        },
        {
            path: "shop",
            element: <Shop />
        },
        {
            path: "moves",
            element: <Moves />
        },
        {
            path:"productDetail/:id",
            element:<ProductDetail/>

        },
        {
            path: "*",
            element: <Error />
        }
    ]
},
{
    path: "/admin",
    element: <AdminRoot />,
    children:
        [
            {
                path: "",
                element: <Dashboard />
            }

        ]
}
]