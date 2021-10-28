package fr.cpe.services;

import fr.cpe.dto.Personne;
import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.annotation.JmsListener;
import org.springframework.stereotype.Service;

@Log4j2
@Service
@RequiredArgsConstructor(onConstructor = @__(@Autowired))
public class Receiver {

    private final Sender sender;

    @JmsListener(destination = "${spring-messaging.queue.name}")
    public void receiveMessage(Personne personne) {
        System.out.println(personne);

        sender.sendMessage(personne);
    }
}
