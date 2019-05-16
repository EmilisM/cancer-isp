import React from "react";
import { Card, Row, Col, ListGroup, ListGroupItem, Image, Form, Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import propTypes from "prop-types";
import { FaFilter } from "react-icons/fa";

function mapStateToProps(state) {
    return {
        loggedIn: state.loggedIn
    }
}

function TopSongCard({ songs, showFilter, onClick, onSubmit, onChange, rangeDays }) {
    TopSongCard.propTypes = {
        songs: propTypes.array,
        showFilter: propTypes.bool,
        onClick: propTypes.func,
        onSubmit: propTypes.func,
        onChange: propTypes.func,
        rangeDays: propTypes.number
    }

    return (
        <Row>
            <Col>
                <Card>
                    <Card.Header>
                        <Row>
                            <Col>
                                Top songs
                            </Col>
                            <Col>
                                <FaFilter style={{ cursor: "pointer" }} onClick={onClick}/>
                            </Col>
                        </Row>
                    </Card.Header>
                    {showFilter
                        ? <Card.Body id="filter">
                              <Form onSubmit={onSubmit}>
                                  <Form.Group>
                                      <Form.Label>Top song period</Form.Label>
                                      <Form.Control as="select" onChange={onChange}>
                                          <option value="7" selected={rangeDays === 7}>1 week</option>
                                          <option value="30" selected={rangeDays === 30}>1 month</option>
                                          <option value="180" selected={rangeDays === 180}>6 months</option>
                                          <option value="0" selected={rangeDays === 0}>All time</option>
                                      </Form.Control>
                                  </Form.Group>

                                  <Button variant="primary" type="submit">
                                      Filter
                                  </Button>
                              </Form>
                          </Card.Body>
                        : <ListGroup className="list-group-flush">
                              {songs.map(song => (
                                  <ListGroupItem key={song.song.id}>
                                      <Row>
                                          <Col>
                                              <Image src={song.song.image.url}/>
                                              <Link to={`/song/${song.song.id}`}>
                                                  {song.song.artists.map(artist => artist.artist.alias)
                                                      .join(", ")} - {song
                                                          .song.name}
                                              </Link>
                                          </Col>
                                          <Col align="right">
                                              {song.averageRating}
                                          </Col>
                                      </Row>
                                  </ListGroupItem>
                              ))}
                          </ListGroup>
                    }
                </Card>
            </Col>
        </Row>
    );
}

function MusicRecommendationCard() {
    return (
        <Row>
            <Col>
                <Card>
                    <Card.Header>
                        Recommendation card
                    </Card.Header>
                    <Card.Body>
                        <div className="form-group">
                            Recommendations for you dear !
                        </div>
                    </Card.Body>
                </Card>
            </Col>
        </Row>
    );
}

function HomeGreetingCard({ loggedIn }) {
    HomeGreetingCard.propTypes = {
        loggedIn: propTypes.bool
    }

    return (
        <Row>
            <Col>
                <Card>
                    <Card.Header>
                        Hello!
                    </Card.Header>
                    <Card.Body>
                        <div className="form-group">
                            Welcome to music rating site.
                        </div>
                        {loggedIn
                            ? <div> </div>
                            : <div>
                                  <div className="form-group">
                                      <Link to="/login">To login page</Link>
                                  </div>
                                  <div className="form-group">
                                      <Link to="/signup">To sign up page</Link>
                                  </div>
                              </div>}
                    </Card.Body>
                </Card>
            </Col>
        </Row>
    );
}

class Home extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            songs: [],
            showFilter: false,
            rangeDays: "30"
        };

        this.onFilterClick = this.onFilterClick.bind(this);
        this.onFilterSubmit = this.onFilterSubmit.bind(this);
        this.onFilterChange = this.onFilterChange.bind(this);
    }

    onFilterClick() {
        this.setState({
            showFilter: !this.state.showFilter
        });
    }

    onFilterSubmit(e) {
        e.preventDefault();

        fetch(`api/home/top/${this.state.rangeDays}`)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        songs: result,
                        showFilter: false
                    });
                });
    }

    onFilterChange(e) {
        e.preventDefault();
        this.setState({
            rangeDays: e.target.value
        });
    }

    componentDidMount() {
        fetch(`api/home/top/${this.state.rangeDays}`)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        songs: result
                    });
                });
    }

    render() {
        return (
            <div>
                <Row>
                    <Col>

                        <Row>
                            <Col>
                                <HomeGreetingCard {...this.props}/>
                            </Col>
                        </Row>

                    </Col>
                </Row>

                <Row>
                    <Col>
                        <Row>
                            <Col>
                                <TopSongCard {...this.state} onClick={this.onFilterClick} onSubmit={this.onFilterSubmit
} onChange={this.onFilterChange}/>
                            </Col>
                            <Col>
                                <MusicRecommendationCard/>
                            </Col>
                        </Row>
                    </Col>
                </Row>
            </div>
        );
    }
}

export default connect(mapStateToProps)(Home);