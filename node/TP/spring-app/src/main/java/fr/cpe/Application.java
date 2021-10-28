package fr.cpe;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.jms.DefaultJmsListenerContainerFactoryConfigurer;
import org.springframework.context.annotation.Bean;
import org.springframework.jms.annotation.EnableJms;
import org.springframework.jms.config.DefaultJmsListenerContainerFactory;
import org.springframework.jms.config.JmsListenerContainerFactory;
import org.springframework.jms.config.JmsListenerEndpointRegistrar;
import org.springframework.jms.support.converter.MappingJackson2MessageConverter;
import org.springframework.jms.support.converter.MessageConverter;
import org.springframework.jms.support.converter.MessageType;

import javax.jms.ConnectionFactory;

@SpringBootApplication
public class Application {

//	TEST SENDER
//	public static void main(String[] args) {
//		 Launch the application
//		ConfigurableApplicationContext context = SpringApplication.run(Application.class, args);
//
//		System.out.println("Sending an personne message.");
//		Sender sender = context.getBean(Sender.class);
//		sender.sendMessage(Personne.builder().nom("ROUQUET").prenom("Adrien").build());
//	}

	public static void main(String[] args) {
		// Launch the application
		SpringApplication.run(Application.class, args);
	}
}
