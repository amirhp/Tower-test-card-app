import React, { useState } from 'react'
import { Container, Grid } from '@material-ui/core'
import Header from '../Header/Header'
import { useHistory } from 'react-router-dom'
import Menu from '../../models/Menu';


type MasterProps = {
  routes: Menu[],
  children?: React.ReactNode
}

const Master: React.FC<MasterProps> = ({ routes, children }: MasterProps)  => {

  const history = useHistory()

  const [showMenus, setShowMenus] = useState(false)
  const [headerTitle, setHeaderTitle] = useState('')

  const toggleMenu = (): void => {
    const targetState =!showMenus 

    setShowMenus(targetState)

    const routeItem = routes.find((m) => m.showMenus === targetState)
    if (routeItem) {
      setHeaderTitle(routeItem.title)
      history.push(routeItem.path)
    }
  }
  
  return (
    <div>
      <Container maxWidth={false} disableGutters data-testid="Main">
        <Grid container direction="row" justify="center" alignItems="center">
          <Header
            title={headerTitle}
            isMenuShowing={showMenus}
            toggleMenu={toggleMenu}
            data-testid="Header"
          />
        </Grid>
        {children}
      </Container>
    </div>
  )
}

export default Master;
