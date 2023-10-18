import * as React from 'react';
import Paper from '@mui/material/Paper';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TablePagination from '@mui/material/TablePagination';
import TableRow from '@mui/material/TableRow';
import { Link } from 'react-router-dom';

const columns=[
    {id:'id',label:'Id',minWidth:170},
    {id:'name',label:'Name',minWidth:170},
    {id:'description',label:'Description',minWidth:170},
    {id:'price',label:'Price',minWidth:170},
]

const rows=[
    {id:1,name:"Asiman",description:"yaxsi oglan",price:100},
    {id:2,name:"Sahub",description:"yaxsi oglan",price:200},
    {id:3,name:"Ali",description:"yaxsi oglan",price:300},
    
]

const AdminPanelTable = ({Rows,Columns}) => {
    const [page, setPage] = React.useState(0);
    const [rowsPerPage, setRowsPerPage] = React.useState(10);
    const rows=Rows;
    const columns=Columns;
    const handleChangePage = (event, newPage) => {
      setPage(newPage);
    };
  
    const handleChangeRowsPerPage = (event) => {
      setRowsPerPage(+event.target.value);
      setPage(0);
    };
  
    return (
      <Paper sx={{ width: '100%', overflow: 'hidden' }}>
        <TableContainer sx={{ maxHeight: 440 }}>
          <Table stickyHeader aria-label="sticky table">
            <TableHead>
              <TableRow>
                {columns.map((column) => (
                  <TableCell
                    key={column.id}
                    align={column.align}
                    style={{ minWidth: column.minWidth }}
                  >
                    {column.label}
                  </TableCell>
                ))}
              </TableRow>
            </TableHead>
            <TableBody>
              {rows
                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                .map((row) => {
                  return (
                    <TableRow hover role="checkbox" tabIndex={-1} key={row.id}>
                      {columns.map((column,i) => {
                        const value = row[column.id];
                        return (
                          <TableCell key={column.id} align={column.align}>
                                                    {column.id === 'image' ? (
                                                        <img src={value} alt="Product" style={{ maxWidth: '100px' }} />
                                                    ) : (
                                                        column.format && typeof value === 'number'
                                                            ? column.format(value)
                                                            : (column.id==='buttons'?(
                                                              <div className='buttons'>
                                                              <Link className='btn btn-primary' to={value.detail}>Detail</Link>
                                                              <Link className='btn btn-warning' to={value.update}>Update</Link>
                                                              <Link className='btn btn-danger' to={value.delete}>Delete</Link>
                                                              </div>
                                                            )
                                                              :value)
                                                    )}
                                                </TableCell>
                        );
                      })}
                    </TableRow>
                  );
                })}
            </TableBody>
          </Table>
        </TableContainer>
        <TablePagination
          rowsPerPageOptions={[1,3, 5,10,100]}
          component="div"
          count={rows.length}
          rowsPerPage={rowsPerPage}
          page={page}
          onPageChange={handleChangePage}
          onRowsPerPageChange={handleChangeRowsPerPage}
        />
      </Paper>
    );
}

export default AdminPanelTable