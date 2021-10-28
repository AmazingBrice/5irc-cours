package fr.cpe.services;

import fr.cpe.dto.Personne;
import lombok.Data;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.env.Environment;
import org.springframework.jms.core.JmsTemplate;
import org.springframework.stereotype.Service;

import javax.annotation.PostConstruct;

@Service
@RequiredArgsConstructor(onConstructor = @__(@Autowired))
@Data
public class Sender {

    private final JmsTemplate jmsTemplate;

    private static final String QUEUE_KEY = "nodejs-messaging.queue.name";

    private String queue;

    private final Environment environment;

    @PostConstruct
    public void init() {
        queue = environment.getProperty(QUEUE_KEY);
    }

    public void sendMessage(Personne personne) {

        // Send a message with a POJO - the template reuse the message converter
        System.out.println("Sending an personne message.");
        personne.setSpring("OK");
        jmsTemplate.convertAndSend(queue, personne);
    }
}
