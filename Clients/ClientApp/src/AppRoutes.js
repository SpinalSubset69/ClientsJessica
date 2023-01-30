import { BillsPage } from "./pages/bills";
import { Home } from "./pages/Home/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  }, {
    index: false,
    path: 'bills',
    element: <BillsPage />
  }
];

export default AppRoutes;
