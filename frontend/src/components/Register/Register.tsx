import React, { useState } from 'react'
import { Paper, Grid, Typography, Button } from '@material-ui/core'
import { createStyles, makeStyles, Theme } from '@material-ui/core/styles'
import { CreditCard as CreditCardIcon } from '@material-ui/icons'
import CreditCard from '../../models/CreaditCard'

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      flexGrow: 1,
      overflow: 'hidden',
      padding: theme.spacing(0, 3)
     
    },
    textField: {
      marginBottom: theme.spacing(3)      
    },  
    content: {
      textAlign: 'center',
    },  paper: {
      marginTop: theme.spacing(8),
      display: 'flex',
      flexDirection: 'column',
      alignItems: 'center',
    },
       form: {
      width: '100%', // Fix IE 11 issue.
      marginTop: theme.spacing(1),
    },
    submit: {
      margin: theme.spacing(3, 0, 2),
    }
  })
)



export interface RegisterProps {
  onSubmitClicked: (data: CreditCard) => Promise<void>
}

const Register: React.FC<RegisterProps> = ({
  onSubmitClicked,
}: RegisterProps) => {
  const classes = useStyles()

  const [cardNumber, setCardNumber] = useState('')
  const [cvcNumber, setCvcNumber] = useState('')
  const [expiryDate, setExpiryDate] = useState('')

  const onCardNumberChange = (e: React.ChangeEvent<HTMLInputElement>): void => {
    setCardNumber(e.target.value)
  }

  const onCvcNumberChange = (e: React.ChangeEvent<HTMLInputElement>): void => {
    setCvcNumber(e.target.value)
  }

  const onExpiryDateChange = (e: React.ChangeEvent<HTMLInputElement>): void => {
    setExpiryDate(e.target.value)
  }


  const onSubmit = async (
    e: React.FormEvent<HTMLFormElement>
  ): Promise<void> => {
    e.preventDefault()


    const creditCard: CreditCard = {
      cardNumber,
      cvcNumber,
      expiryDate,
    }

    await onSubmitClicked(creditCard)
  }

  return (
    <div className={classes.root}>
      <Paper elevation={0} className={classes.paper}>
        <Grid container direction="row" justify="center" alignItems="center">
          <Typography variant="h6" className={classes.content}>
            <div>Welcome</div>
          </Typography>
        </Grid>
      </Paper>
      <Paper elevation={0} className={classes.paper}>
        <Grid
          container
          direction="row"
          justify="center"
          alignItems="center"
          spacing={2}
        >
          <Grid item xs={12} xl={10} sm={8} md={6} lg={4}>
            <form className={classes.form}  onSubmit={onSubmit} data-testid="form">
              <div className={classes.textField}>
              <span>Card Number</span>
                <input
                  value={cardNumber}
                />
            
                {/* CardNumberTextBox */}
              </div>
              <div className={classes.textField}>
                <Grid
                  container
                  direction="row"
                  justify="flex-end"
                  alignItems="center"
                  spacing={2}
                >
                  <Grid item xs={6} xl={5} sm={4} md={3} lg={4}>
                    {/* CvcNumberTextBox */}
                    <span>CVC</span>
                    <input
                      value={cvcNumber}
                    />
                  </Grid>
                  <Grid item xs={6} xl={5} sm={4} md={3} lg={4}>
                  {/* ExpiryDateTextBox */}
                  <span>Card Number</span>
                  <input
                      value={cardNumber}
                    />
                   
                  </Grid>
                </Grid>
              </div>
              <div className={classes.textField}>
                <Button
                  size="large"
                  fullWidth
                  variant="contained"
                  color="primary"
                  type="submit"
                >
                  Pay
                </Button>
              </div>
            </form>
          </Grid>
        </Grid>
      </Paper>
    </div>
  )
}

export default Register
