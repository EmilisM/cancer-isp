import React from "react";
import { Card, Row, Col, Form, Button, Alert } from "react-bootstrap";
import propTypes from "prop-types";

function DonationCard({ donationAmount, onInputChange, onFormSubmit, cardConfirmation, onConfirmationFormSubmit }) {
    DonationCard.propTypes = {
        onInputChange: propTypes.func,
        onFormSubmit: propTypes.func,
        donationAmount: propTypes.string,
        cardConfirmation: propTypes.bool,
        onConfirmationFormSubmit: propTypes.func
    }

    return (
        <Card>
            <Card.Header>
                Support our page
            </Card.Header>
            <Card.Body>
                {cardConfirmation === false
                    ? <Form onSubmit={onFormSubmit}>
                          <Form.Group>
                              <Form.Label>Donation amount</Form.Label>
                              <Form.Control placeholder="Eg. 80" name="donationAmount" onChange={onInputChange} value={
                                donationAmount}/>
                          </Form.Group>
                          <Form.Group>
                              <Button variant="primary" type="submit">
                                  Submit donation
                              </Button>
                          </Form.Group>
                      </Form>
                    : <Form onSubmit={onConfirmationFormSubmit}>
                          <Form.Group>
                              <Form.Label>Are you sure you want to donate {donationAmount}?</Form.Label>
                          </Form.Group>
                          <Form.Group>
                              <Button variant="primary" type="submit">
                                  Confirm
                              </Button>
                          </Form.Group>
                      </Form>}
            </Card.Body>
        </Card>
    );
}

class Donate extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            donationAmount: "",
            cardConfirmation: false,
            confirmation: false
        };


        this.onInputChange = this.onInputChange.bind(this);
        this.onFormSubmit = this.onFormSubmit.bind(this);
        this.onConfirmationFormSubmit = this.onConfirmationFormSubmit.bind(this);
    }

    onConfirmationFormSubmit(e) {
        e.preventDefault();

        this.setState({
            confirmation: true
        });
    }

    onFormSubmit(e) {
        e.preventDefault();

        this.setState({
            cardConfirmation: !this.state.cardConfirmation
        });
    }

    onInputChange(e) {
        e.preventDefault();

        this.setState({
            [e.target.name]: e.target.value
        });
    }

    render() {
        return (
            <div>
                {this.state.confirmation
                    ? <Row>
                          <Col>
                              <Alert variant="success">Thank you for donating!</Alert>
                          </Col>
                      </Row>
                    : <Row>
                          <Col>

                              <Row>
                                  <Col>
                                      <DonationCard onInputChange={this.onInputChange} onFormSubmit={this.onFormSubmit
} {...this.state} onConfirmationFormSubmit={this.onConfirmationFormSubmit}/>
                                  </Col>
                              </Row>

                              <Row>
                                  <Col>
                                  </Col>
                              </Row>

                          </Col>
                          <Col>

                              <Row>
                                  <Col>

                                  </Col>
                              </Row>

                          </Col>
                      </Row>
                }
            </div>
        );
    }
}

export default Donate;