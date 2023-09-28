import React from 'react'
import Button from '@mui/material/Button';
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import PopupState, { bindTrigger, bindMenu } from 'material-ui-popup-state';


const HoverMenu = ({Title,Children}) => {
  return (
    <PopupState variant="popover" popupId="demo-popup-menu">
      {(popupState) => (
        <React.Fragment>
          <Button className='bg-white from-blue-800' variant="" {...bindTrigger(popupState)}>
            <p className='text-white font-bold text-base'> {Title}</p>
          </Button>
          <Menu {...bindMenu(popupState)}>
            {Children.map((child,index)=>{
            return <MenuItem key={index} onClick={popupState.close}>{child}</MenuItem>
            })}
           
          </Menu>
        </React.Fragment>
      )}
    </PopupState>
  )
}

export default HoverMenu