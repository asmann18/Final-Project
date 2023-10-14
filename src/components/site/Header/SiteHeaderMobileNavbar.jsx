import React, { useState } from 'react';
import {
  AppBar,
  Toolbar,
  IconButton,
  Typography,
  Container,
  Accordion,
  AccordionSummary,
  AccordionDetails,
} from '@mui/material';
import MenuIcon from '@mui/icons-material/Menu';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';

function SiteHeaderNavbar() {
  const [menuOpen, setMenuOpen] = useState(false);

  const toggleMenu = () => {
    setMenuOpen(!menuOpen);
  };

  return (
    <div>
      <AppBar position="static">
        <Toolbar>
          <IconButton
            edge="start"
            color="inherit"
            aria-label="menu"
            onClick={toggleMenu}
          >
            <MenuIcon />
          </IconButton>
          {/* <Typography variant="h6">Hamburger Menu</Typography> */}
        </Toolbar>
      </AppBar>

      <div style={{ display: 'flex' }}>
        <nav style={{ width: menuOpen ? '250px' : '0', transition: '0.3s' }}>
          <Container>
            <Accordion>
              <AccordionSummary expandIcon={<ExpandMoreIcon />}>
                <Typography>Section 1</Typography>
              </AccordionSummary>
              <AccordionDetails>
                <Typography>
                  Content of section 1 goes here.
                </Typography>
              </AccordionDetails>
            </Accordion>

            <Accordion>
              <AccordionSummary expandIcon={<ExpandMoreIcon />}>
                <Typography>Section 2</Typography>
              </AccordionSummary>
              <AccordionDetails>
                <Typography>
                  Content of section 2 goes here.
                </Typography>
              </AccordionDetails>
            </Accordion>
          </Container>
        </nav>

        <main style={{ flex: 1 }}>
          {/* Main content of your page goes here */}
        </main>
      </div>
    </div>
  );
}

export default SiteHeaderNavbar;
